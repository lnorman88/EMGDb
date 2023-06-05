using EMGDb.Application.CQRS.Game.CreateGame;
using EMGDb.Application.CQRS.Game.DeleteGame;
using EMGDb.Application.CQRS.Game.GetAllGames;
using EMGDb.Domain.DTOs.Media;
using EMGDb.Domain.Entities.Media;
using EMGDb.Domain.Filters;
using EMGDb.WebApi.Controllers;
using EMGDb.WebApi.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System.Net;

namespace EMGDb.WebApi.Tests.Controllers
{
    [TestFixture]
    public class GamesControllerTests
    {
        private IMediator _mediator;
        private GamesController _gameController;

        [SetUp]
        public void SetUp()
        {
            _mediator = Substitute.For<IMediator>();
            _gameController = new GamesController(_mediator);
        }

        //CreateGameEntry Endpoint START
        [Test]
        public async Task CreateGameEntry_WhenCreateGameQueryReturns200_ShouldReturnOkObjectResult()
        {
            //Arrange
            var createGameDto = new CreateGameDto
            {
                Cast = "Cast1, Cast2",
                Crew = "Crew1, Crew3",
                Directors = "Director",
                Writers = "Writer1, writer2",
                Title = "Title",
                ReleaseDate = DateTime.UtcNow,
                Genre = 0,
                Platforms = 0
            };
            _mediator.Send(Arg.Any<CreateGameQuery>()).Returns(200);

            //Act
            var response = await _gameController.CreateGameEntry(createGameDto);

            //Assert
            var createdResult = response.ShouldBeOfType<OkObjectResult>();
            createdResult.StatusCode.ShouldBe((int) HttpStatusCode.OK);
        }

        [Test]
        public async Task CreateGameEntry_WhenCreateGameQueryDoesNotReturn200_ShouldReturnBadRequestResult()
        {
            //Arrange
            var createGameDto = new CreateGameDto
            {
                Cast = "Cast1, Cast2",
                Crew = "Crew1, Crew3",
                Directors = "Director",
                Writers = "Writer1, writer2",
                Title = "Title",
                ReleaseDate = DateTime.UtcNow,
                Genre = 0,
                Platforms = 0
            };
            _mediator.Send(Arg.Any<CreateGameQuery>()).Returns(400);

            //Act
            var response = await _gameController.CreateGameEntry(createGameDto);

            //Assert
            var createdResult = response.ShouldBeOfType<BadRequestResult>();
            createdResult.StatusCode.ShouldBe((int) HttpStatusCode.BadRequest);
        }
        //CreateGameEntry Endpoint END

        //GetAllGameEntries Endpoint START
        [Test]
        public async Task GetAllGameEntries_WhenGetAllGamesQueryReturnsGameEntityList_ShouldReturnGameDtoList()
        {
            //Arrange
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            var dateTime = DateTime.UtcNow;
            var entityList = new List<GameEntity>
            {
                new GameEntity
                {
                    Id = guid1,
                    Cast = "Cast1",
                    Crew = "Crew1",
                    Directors = "Director1",
                    Writers = "Writers1",
                    ReleaseDate = dateTime,
                    Title = "Title1",
                    Genre = 0,
                    Platforms = 0
                },
                new GameEntity
                {
                    Id = guid2,
                    Cast = "Cast2",
                    Crew = "Crew2",
                    Directors = "Director2",
                    Writers = "Writers2",
                    ReleaseDate = dateTime,
                    Title = "Title2",
                    Genre = 0,
                    Platforms = 0
                }
            };
            var expectedResult = new List<GameDto>()
            {
                new GameDto
                {
                    Id = guid1,
                    Cast = "Cast1",
                    Crew = "Crew1",
                    Directors = "Director1",
                    Writers = "Writers1",
                    ReleaseDate = dateTime,
                    Title = "Title1",
                    Genre = 0,
                    Platforms = 0
                },
                new GameDto
                {
                    Id = guid2,
                    Cast = "Cast2",
                    Crew = "Crew2",
                    Directors = "Director2",
                    Writers = "Writers2",
                    ReleaseDate = dateTime,
                    Title = "Title2",
                    Genre = 0,
                    Platforms = 0
                }
            };
            _mediator.Send(Arg.Any<GetAllGamesQuery>()).Returns(entityList);

            //Act
            var response = await _gameController.GetAllGameEntries(new GameFilter());

            //Assert
            var okObjectResult = response as OkObjectResult;
            var responseList = (IEnumerable<GameDto>) okObjectResult.Value!;
            responseList.First().ShouldBeEquivalentTo(expectedResult.First());
        }

        [Test]
        public async Task GetAllGameEntries_WhenGetAllGamesQueryReturnsEmptyList_ShouldReturnBadRequest()
        {
            //Arrange            
            _mediator.Send(Arg.Any<GetAllGamesQuery>()).Returns(new List<GameEntity>());

            //Act
            var response = await _gameController.GetAllGameEntries(new GameFilter());

            //Assert
            var badRequestResult = response as BadRequestResult;
            badRequestResult.StatusCode.ShouldBe((int) HttpStatusCode.BadRequest);
        }
        //GetAllGameEntries Endpoint END

        //DeleteGameEntry Endpoint START
        [Test]
        public async Task DeleteGameEntry_WhenValidIdIsGiven_ShouldReturnOkObjectResult()
        {
            //Arrange
            var guidAsString = Guid.NewGuid().ToString();
            _mediator.Send(Arg.Any<DeleteGameQuery>()).Returns(200);

            //Act
            var response = await _gameController.DeleteGameEntry(guidAsString);

            //Assert
            var createdResult = response.ShouldBeOfType<OkObjectResult>();
            createdResult.StatusCode.ShouldBe((int) HttpStatusCode.OK);
        }

        [Test]
        [TestCase("")]
        [TestCase("TestCase")]
        [TestCase(null)]
        public async Task DeleteGameEntry_WhenInvalidIdIsGiven_ShouldReturnBadRequest(string id)
        {
            //Act
            var response = await _gameController.DeleteGameEntry(id);

            //Assert
            var createdResult = response.ShouldBeOfType<BadRequestResult>();
            createdResult.StatusCode.ShouldBe((int) HttpStatusCode.BadRequest);
        }
        //DeleteGameEntry Endpoint END
    }
}
