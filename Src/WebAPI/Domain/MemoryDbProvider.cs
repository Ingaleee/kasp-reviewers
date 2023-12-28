namespace Tasks.Domain;

public class MemoryDbProvider<TContext> : IDbProvider<TContext>  
    where TContext : class 
{
    private readonly TContext _context;

    public MemoryDbProvider(TContext context)
    {
        _context = context;
    }

    public TContext Context()
    {
        return _context;
    }
}