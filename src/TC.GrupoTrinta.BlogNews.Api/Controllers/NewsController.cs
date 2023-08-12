using MediatR;
using Microsoft.AspNetCore.Mvc;
using TC.GrupoTrinta.BlogNews.Application.UseCases.News.Common;
using TC.GrupoTrinta.BlogNews.Application.UseCases.News.CreateNews;

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

}
