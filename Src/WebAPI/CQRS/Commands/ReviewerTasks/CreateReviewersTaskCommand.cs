using MediatR;

namespace Tasks.CQRS.Commands.ReviewerTasks;

public class CreateReviewersTaskCommand : IRequest<EffectHandleResult>
{
    public string Path { get; set; }
    public string RulePath { get; set; }
}