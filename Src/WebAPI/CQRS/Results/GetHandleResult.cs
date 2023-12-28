namespace Tasks.CQRS;

public class GetHandleResult<TResult> : AbstractHandleResult where TResult: class
{
    public TResult Object { get; set; }

    public static GetHandleResult<TResult> Success(TResult result)
    {
        return new GetHandleResult<TResult>()
        {
            Object = result,
            IsSuccess = true,
            Error = null,
        };
    }
    
    public static GetHandleResult<TResult> Failed(string error)
    {
        return new GetHandleResult<TResult>()
        {
            IsSuccess = false,
            Error = error,
            Object = null
        };
    }
}