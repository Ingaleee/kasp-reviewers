namespace Tasks.Domain;

public interface IDbProvider<out TContext>
{
    TContext Context();
}