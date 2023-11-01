using MediatR;
using Microsoft.AspNetCore.Mvc;
using TC.GrupoTrinta.BlogNews.Application.UseCases.News.Common;
using TC.GrupoTrinta.BlogNews.Application.UseCases.News.CreateNews;
using TC.GrupoTrinta.BlogNews.Application.UseCases.News.GetNews;

namespace TC.GrupoTrinta.BlogNews.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsController : ControllerBase
{
    private readonly IMediator _mediator;

    public NewsController(IMediator mediator)
        => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(typeof(NewsModelOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create(
        [FromBody] CreateNewsInput input,
        CancellationToken cancellationToken
    )
    {
        var output = await _mediator.Send(input, cancellationToken);
        return CreatedAtAction(
            nameof(Create),
            new { output.Id },
            output
        );
    }

    [HttpGet("GetById")]
    [ProducesResponseType(typeof(NewsModelOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    public IActionResult GetById(
    [FromQuery] GetByIdNewsInput command,
    CancellationToken cancellationToken
    )
    {
        var result =  _mediator.Send(command, cancellationToken);
        return Ok(result.Result);
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(NewsModelOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    public IActionResult GetAll(   
    CancellationToken cancellationToken
    )
    {
        var result =  _mediator.Send(new GetAllNewsInput(), cancellationToken);
        return Ok(result.Result);
    }

}
