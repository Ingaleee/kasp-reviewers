namespace Tasks.CQRS;

public abstract class AbstractHandleResult
{
    public string? Error { get; set; }
    public bool IsSuccess { get; set; } 
    
}