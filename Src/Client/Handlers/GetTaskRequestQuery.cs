using MediatR;

namespace Client.Handlers;

public class GetTaskRequestQuery : IRequest
{
    public ulong Id { get; set; }
}