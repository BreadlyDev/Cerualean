namespace BusinessLogic.Dtos.UserPractice;

public class ExecutionResult
{
    public bool HasErrors { get; set; }
    public List<string>? Errors { get; set; }
    public string? Output { get; set; }
    public string? ReturnValue { get; set; }
}
