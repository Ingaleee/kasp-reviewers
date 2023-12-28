using MediatR;

namespace Client.Handlers;

public class CreateTaskRequestCommand : IRequest
{
    public string Path { get; set; }
    public string Rules { get; set; }
}