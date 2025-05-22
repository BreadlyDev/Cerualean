using BusinessLogic.Dtos.UserPractice;

namespace BusinessLogic.Abstractions;

public interface ICodeRunnerService
{
    Task<ExecutionResult> CompileAndRunAsync(string code);
}
