using Client.API;
using MediatR;
using TaskStatus = System.Threading.Tasks.TaskStatus;

namespace Client.Handlers;

public class GetTaskRequestHandler : IRequestHandler<GetTaskRequestQuery>
{
    private readonly ReviewersTaskAPI _api;

    public GetTaskRequestHandler(ReviewersTaskAPI api)
    {
        _api = api;
    }
    public async Task Handle(GetTaskRequestQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _api.GetByIdAsync(request.Id);
            if (result.Status == ReviewersTaskStatus.InProgress)
            {
                Console.WriteLine($"Task {result.Id} is still in progress");
                return;
            }
    
            Console.WriteLine($"Path: {result.Path}");
            Console.WriteLine($"Reviewers: {string.Join("; ", result.Reviewers)}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}