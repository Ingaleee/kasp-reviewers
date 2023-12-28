using AutoMapper;
using Tasks.CQRS.Queries.ReviewerTasks;

namespace Tasks.Views.Tasks;

public class ReviewersTaskControllerMapping : Profile
{
    public ReviewersTaskControllerMapping()
    {
        CreateMap<ReviewersTaskModel, ReviewersTaskWebResult>();
    }
}