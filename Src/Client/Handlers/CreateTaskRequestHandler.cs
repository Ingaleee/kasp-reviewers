using Client.API;
using MediatR;

namespace Client.Handlers;

public class CreateTaskRequestHandler : IRequestHandler<CreateTaskRequestCommand>
{
    private readonly ReviewersTaskAPI _api;

    public CreateTaskRequestHandler(ReviewersTaskAPI api)
    {
        _api = api;
    }
    
    public async Task Handle(CreateTaskRequestCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var apiRequest = new CreateReviewersTaskWebRequest
            {
                Path = request.Path,
                RulePath = request.Rules
            };
            var createdId = await _api.CreateAsync(apiRequest);
            Console.WriteLine($"Reviewers task has been created (id: #{createdId})");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}