using MediatR;

namespace Tasks.CQRS.Requests;

public abstract class EntityHandlerRequest<TEntity> : IRequest<TEntity>
{
    public ulong Id { get; set; }

    protected EntityHandlerRequest(ulong id)
    {
        Id = id;
    }
}