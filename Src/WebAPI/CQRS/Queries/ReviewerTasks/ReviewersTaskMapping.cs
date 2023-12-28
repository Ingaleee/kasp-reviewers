using AutoMapper;
using Tasks.Objects;

namespace Tasks.CQRS.Queries.ReviewerTasks;

public class ReviewersTaskMapping : Profile
{
    public ReviewersTaskMapping()
    {
        CreateMap<ReviewerTask, ReviewersTaskModel>();
    }
}