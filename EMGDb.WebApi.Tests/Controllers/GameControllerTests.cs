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
    public class GameControllerTests
    {
        private IMediator _mediator;
        private GamesController _gameController;

        [SetUp]
        public void SetUp()
        {
            _mediator = Substitute.For<IMediator>();
            _gameController = new GamesController(_mediator);
        }

        [Test]
        public async Task GameControllerTest()
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
            _mediator.Send(createGameDto).Returns(200);

            //Act
            var result = await _gameController.CreateGameEntry(createGameDto);

            //Assert
            var createdResult = result.ShouldBeOfType<OkObjectResult>();
            createdResult.StatusCode.ShouldBe((int) HttpStatusCode.OK);
        }
    }
}
