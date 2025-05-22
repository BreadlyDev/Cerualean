using System.Reflection;
using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.UserPractice;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace BusinessLogic.Services;

internal class CodeRunnerService : ICodeRunnerService
{
    public async Task<ExecutionResult> CompileAndRunAsync(string userCode)
    {
        var fullCode = "using System;\n" + userCode;

        var syntaxTree = CSharpSyntaxTree.ParseText(fullCode);

        var trustedAssembliesPaths = ((string?)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES"))?
            .Split(Path.PathSeparator) ?? Array.Empty<string>();

        var references = trustedAssembliesPaths
            .Where(path =>
                path.EndsWith("System.Runtime.dll", StringComparison.OrdinalIgnoreCase) ||
                path.EndsWith("System.Console.dll", StringComparison.OrdinalIgnoreCase) ||
                path.EndsWith("System.Linq.dll", StringComparison.OrdinalIgnoreCase) ||
                path.EndsWith("netstandard.dll", StringComparison.OrdinalIgnoreCase) ||
                path.EndsWith("System.Private.CoreLib.dll", StringComparison.OrdinalIgnoreCase)
            )
            .Select(path => MetadataReference.CreateFromFile(path))
            .ToList();

        var compilation = CSharpCompilation.Create(
            "UserCodeAssembly",
            new[] { syntaxTree },
            references,
            new CSharpCompilationOptions(OutputKind.ConsoleApplication)
        );

        using var ms = new MemoryStream();
        var result = compilation.Emit(ms);

        if (!result.Success)
        {
            var errors = result.Diagnostics
                .Where(d => d.Severity == DiagnosticSeverity.Error)
                .Select(d => d.ToString())
                .ToList();

            return new ExecutionResult
            {
                HasErrors = true,
                Errors = errors
            };
        }

        ms.Seek(0, SeekOrigin.Begin);
        var assembly = Assembly.Load(ms.ToArray());

        var entryPoint = assembly.EntryPoint;
        var outputWriter = new StringWriter();

        var originalOut = Console.Out;
        Console.SetOut(outputWriter);

        object? returnValue = null;

        try
        {
            var parameters = entryPoint.GetParameters().Length == 0 ? null : new object[] { new string[0] };
            returnValue = entryPoint.Invoke(null, parameters);
        }
        catch (Exception ex)
        {
            return new ExecutionResult
            {
                HasErrors = true,
                Errors = new List<string> { ex.ToString() }
            };
        }
        finally
        {
            Console.SetOut(originalOut);
        }

        return new ExecutionResult
        {
            HasErrors = false,
            Output = outputWriter.ToString(),
            ReturnValue = returnValue?.ToString(),
        };
    }
}
