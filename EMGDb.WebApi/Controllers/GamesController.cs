using EMGDb.Application.CQRS.Game.CreateGame;
using EMGDb.Application.CQRS.Game.DeleteGame;
using EMGDb.Application.CQRS.Game.GetAllGames;
using EMGDb.Domain.Filters;
using EMGDb.WebApi.DTOs;
using EMGDb.WebApi.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EMGDb.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly IMediator _mediator;

    public GamesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGameEntry([FromBody] CreateGameDto createGameDto)
    {
        var result = await _mediator.Send(new CreateGameQuery(createGameDto.ToEntity()));

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGameEntries([FromQuery] GameFilter gameFilter)
    {
        var response = await _mediator.Send(new GetAllGamesQuery(gameFilter));

        var result = response.Select(x => x.ToDto());

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteGameEntry([FromQuery] string gameId)
    {
        if (!string.IsNullOrEmpty(gameId) && Guid.TryParse(gameId, out Guid parsedGameId))
        {
            var result = await _mediator.Send(new DeleteGameQuery(parsedGameId));
            return Ok(result);
        }

        return BadRequest();
    }
}