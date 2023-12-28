using Kasp1_Review.Abstractions;
using Kasp1_Review.Src;
using MediatR;
using Tasks.Domain;
using Tasks.Objects;
using TaskStatus = Tasks.Objects.TaskStatus;

namespace Tasks.CQRS.Commands.ReviewerTasks;

public class CreateReviewersTaskHandler : IRequestHandler<CreateReviewersTaskCommand, EffectHandleResult>
{
    private readonly IRulesReader _rules;
    private readonly IDbProvider<MemoryApplicationContext> _dbProvider;
    private readonly DefaultReviewersCollector _reviewersCollector;

    public CreateReviewersTaskHandler(IDbProvider<MemoryApplicationContext> dbProvider, 
        IRulesReader rules, 
        DefaultReviewersCollector reviewersCollector)
    {
        _rules = rules;
        _dbProvider = dbProvider;
        _reviewersCollector = reviewersCollector;
    }

    public async Task<EffectHandleResult> Handle(CreateReviewersTaskCommand command, CancellationToken cancellationToken)
    {
        var domainContext = _dbProvider.Context();
        
        var newId = (ulong)domainContext.ReviewerTasks.Count + 1;

        try
        {
            var rules = _rules.FromFile(command.RulePath);
            var reviewers = _reviewersCollector.Find(rules, command.Path);

            var newEntity = new ReviewerTask
            {
                Id = newId,
                Path = command.Path,
                Rules = command.RulePath,
                Status = TaskStatus.InProgress,
                Reviewers = reviewers
            };
            
            var added = domainContext.ReviewerTasks.TryAdd(newId, newEntity);
            if (!added)
            {
                EffectHandleResult.Failed("SystemError");
            }

            return EffectHandleResult.Success(newEntity.Id);
        }
        catch (Exception ex)
        {
            return EffectHandleResult.Failed(ex.Message);
        }
    }
}