namespace Tasks.CQRS;

public class EffectHandleResult : AbstractHandleResult
{
    public ulong AffectedId { get; set; }

    public static EffectHandleResult Success(ulong affectedId)
    {
        return new EffectHandleResult()
        {
            IsSuccess = true,
            AffectedId = affectedId
        };
    }
    
    public static EffectHandleResult Failed(string error)
    {
        return new EffectHandleResult()
        {
            IsSuccess = false,
            Error = error
        };
    }
}