using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasks.CQRS.Commands.ReviewerTasks;
using Tasks.CQRS.Queries.ReviewerTasks;
using Tasks.Requests.Tasks;
using Tasks.Views.Tasks;

namespace Tasks.Controllers;


[ApiController]
[Route("api/tasks")]
public class ReviewersTaskController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    
    public ReviewersTaskController(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewersTaskWebResult>> GetByIdAsync(ulong id)
    {
        var query = new GetReviewersTaskQuery(id);
        
        var handleResult = await _mediator.Send(query);
        if (!handleResult.IsSuccess)
        {
            return BadRequest(handleResult.Error);
        }

        var viewResult = _mapper.Map<ReviewersTaskModel, ReviewersTaskWebResult>(handleResult.Object);
        return Ok(viewResult);
    }

    [HttpPost]
    public async Task<ActionResult<ulong>> CreateAsync([FromBody] CreateReviewersTaskWebRequest request)
    {
        var command = new CreateReviewersTaskCommand
        {
            Path = request.Path,
            RulePath = request.RulePath
        };

        var handleResult = await _mediator.Send(command);

        if (!handleResult.IsSuccess)
        {
            return BadRequest(handleResult.Error);
        }

        return Ok(handleResult.AffectedId);
    }
        
}