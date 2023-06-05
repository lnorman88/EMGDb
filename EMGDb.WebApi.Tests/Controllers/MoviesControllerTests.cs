using EMGDb.Application.CQRS.Movie.CreateMovie;
using EMGDb.Application.CQRS.Movie.DeleteMovie;
using EMGDb.Application.CQRS.Movie.GetAllMovies;
using EMGDb.Domain.DTOs;
using EMGDb.Domain.DTOs.Media;
using EMGDb.Domain.Entities.Media;
using EMGDb.Domain.Filters;
using EMGDb.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System.Net;

namespace EMGDb.WebApi.Tests.Controllers;
[TestFixture]
public class MoviesControllerTests
{
    private IMediator _mediator;
    private MoviesController _moviesController;

    [SetUp]
    public void SetUp()
    {
        _mediator = Substitute.For<IMediator>();
        _moviesController = new MoviesController(_mediator);
    }

    //CreateMovieEntry Endpoint START
    [Test]
    public async Task CreateMovieEntry_WhenCreateGameQueryReturns200_ShouldReturnOkObjectResult()
    {
        //Arrange
        _mediator.Send(Arg.Any<CreateMovieQuery>()).Returns(200);

        //Act
        var response = await _moviesController.CreateMovieEntry(new CreateMovieDto());

        //Assert
        var createdResult = response.ShouldBeOfType<OkObjectResult>();
        createdResult.StatusCode.ShouldBe((int) HttpStatusCode.OK);
    }

    [Test]
    public async Task CreateMovieEntry_WhenCreateGameQueryReturns400_ShouldReturnBadRequest()
    {
        //Arrange
        _mediator.Send(Arg.Any<CreateMovieQuery>()).Returns(400);

        //Act
        var response = await _moviesController.CreateMovieEntry(new CreateMovieDto());

        //Assert
        var createdResult = response.ShouldBeOfType<BadRequestResult>();
        createdResult.StatusCode.ShouldBe((int) HttpStatusCode.BadRequest);
    }
    //CreateMovieEntry Endpoint END

    //GetAllMovieEntries Endpoint START
    [Test]
    public async Task GetAllMovieEntries_WhenGetAllMoviesQueryReturnsMovieEntityList_ShouldReturnMovieDtoList()
    {
        //Arrange
        var guid = Guid.NewGuid();
        var dateTime = DateTime.Now;
        var entityList = new List<MovieEntity>()
        {
            new MovieEntity
            {
                Id = guid,
                Cast = "Cast1",
                Crew = "Crew1",
                Directors = "Director1",
                Writers = "Writers1",
                ReleaseDate = dateTime,
                Title = "Title1",
                Genre = 0,
                Runtime = "Runtime"
            }
        };
        var expectedResult = new List<MovieDto>()
        {
            new MovieDto
            {
                Id = guid,
                Cast = "Cast1",
                Crew = "Crew1",
                Directors = "Director1",
                Writers = "Writers1",
                ReleaseDate = dateTime,
                Title = "Title1",
                Genre = 0,
                Runtime = "Runtime"
            }
        };
        _mediator.Send(Arg.Any<GetAllMoviesQuery>()).Returns(entityList);

        //Act
        var response = await _moviesController.GetAllMovieEntries(new MovieFilter());

        //Assert
        var okObjectResult = response as OkObjectResult;
        var responseList = (IEnumerable<MovieDto>) okObjectResult.Value!;
        responseList.First().ShouldBeEquivalentTo(expectedResult.First());
    }

    [Test]
    public async Task GetAllMovieEntries_WhenGetAllMoviesQueryReturnsEmptyList_ShouldReturnBadRequest()
    {
        //Arrange            
        _mediator.Send(Arg.Any<GetAllMoviesQuery>()).Returns(new List<MovieEntity>());

        //Act
        var response = await _moviesController.GetAllMovieEntries(new MovieFilter());

        //Assert
        var badRequestResult = response as BadRequestResult;
        badRequestResult.StatusCode.ShouldBe((int) HttpStatusCode.BadRequest);
    }
    //GetAllMovieEntries Endpoint END

    //DeleteMovieEntry Endpoint START
    [Test]
    public async Task DeleteMovieEntry_WhenValidIdIsGiven_ShouldReturnOkObjectResult()
    {
        //Arrange
        var guidAsString = Guid.NewGuid().ToString();
        _mediator.Send(Arg.Any<DeleteMovieQuery>()).Returns(200);

        //Act
        var response = await _moviesController.DeleteMovieEntry(guidAsString);

        //Assert
        var createdResult = response.ShouldBeOfType<OkObjectResult>();
        createdResult.StatusCode.ShouldBe((int) HttpStatusCode.OK);
    }

    [Test]
    [TestCase("")]
    [TestCase("TestCase")]
    [TestCase(null)]
    public async Task DeleteMovieEntry_WhenInvalidIdIsGiven_ShouldReturnBadRequest(string id)
    {
        //Act
        var response = await _moviesController.DeleteMovieEntry(id);

        //Assert
        var createdResult = response.ShouldBeOfType<BadRequestResult>();
        createdResult.StatusCode.ShouldBe((int) HttpStatusCode.BadRequest);
    }
    //DeleteMovieEntry Endpoint END
}
