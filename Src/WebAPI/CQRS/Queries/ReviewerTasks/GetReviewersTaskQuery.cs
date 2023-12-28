using MediatR;
using Tasks.CQRS.Requests;

namespace Tasks.CQRS.Queries.ReviewerTasks;

public class GetReviewersTaskQuery : EntityHandlerRequest<GetHandleResult<ReviewersTaskModel>>
{
    public GetReviewersTaskQuery(ulong id) : base(id)
    {
    }
}