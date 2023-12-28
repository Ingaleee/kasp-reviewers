using AutoMapper;
using MediatR;
using Tasks.Domain;

namespace Tasks.CQRS.Queries.ReviewerTasks;

public class GetReviewerTaskHandler : IRequestHandler<GetReviewersTaskQuery, GetHandleResult<ReviewersTaskModel>>
{
    private readonly IMapper _mapper;
    private readonly IDbProvider<MemoryApplicationContext> _dbProvider;

    public GetReviewerTaskHandler(IMapper mapper, 
        IDbProvider<MemoryApplicationContext> dbProvider)
    {
        _mapper = mapper;
        _dbProvider = dbProvider;
    }
    
    public async Task<GetHandleResult<ReviewersTaskModel>> Handle(GetReviewersTaskQuery query, CancellationToken cancellationToken)
    {
        var domainContext = _dbProvider.Context();

        var isExists = domainContext.ReviewerTasks.TryGetValue(query.Id, out var entity);
        if (!isExists)
        {
            return new GetHandleResult<ReviewersTaskModel>
            {
                Error = "EntityNotFound",
                IsSuccess = false
            };
        }

        var model = _mapper.Map<ReviewersTaskModel>(entity);
        return GetHandleResult<ReviewersTaskModel>.Success(model);
    }
}