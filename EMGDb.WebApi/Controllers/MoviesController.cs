using EMGDb.Application.CQRS.Game.DeleteGame;
using EMGDb.Application.CQRS.Movie.CreateMovie;
using EMGDb.Application.CQRS.Movie.GetAllMovies;
using EMGDb.Domain.DTOs;
using EMGDb.Domain.Filters;
using EMGDb.WebApi.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EMGDb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovieEntry([FromBody] CreateMovieDto createMovieDto)
        {
            var result = await _mediator.Send(new CreateMovieEntryQuery(createMovieDto.ToEntity()));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovieEntries([FromQuery] MovieFilter movieFilter)
        {
            var response = await _mediator.Send(new GetAllMoviesQuery(movieFilter));

            var result = response.Select(x => x.ToDto());

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovieEntry([FromQuery] string movieId)
        {
            if (!string.IsNullOrEmpty(movieId) && Guid.TryParse(movieId, out Guid parsedMovieId))
            {
                var result = await _mediator.Send(new DeleteGameQuery(parsedMovieId));
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
