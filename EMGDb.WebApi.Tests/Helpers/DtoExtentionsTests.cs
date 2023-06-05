using EMGDb.Domain.DTOs.Media;
using EMGDb.Domain.Entities.Media;
using EMGDb.WebApi.DTOs;
using EMGDb.WebApi.Helpers;
using NUnit.Framework;
using Shouldly;

namespace EMGDb.WebApi.Tests.Helpers;
[TestFixture]
public class DtoExtentionsTests
{
    //Game Entity/Dto START
    [Test]
    public void CreateGameDtoToEntity_WithValidCreateGameDto_ShouldReturnGameEntity()
    {
        //Arrange
        var dateTime = DateTime.Now;
        var createGameDto = new CreateGameDto
        {
            Title = "Title",
            ReleaseDate = dateTime,
            Cast = "Cast",
            Crew = "Crew",
            Directors = "Directors",
            Writers = "Writers",
            Genre = 0,
            Platforms = 0
        };
        var expectedResult = new GameEntity
        {
            Title = "Title",
            ReleaseDate = dateTime,
            Cast = "Cast",
            Crew = "Crew",
            Directors = "Directors",
            Writers = "Writers",
            Genre = 0,
            Platforms = 0
        };

        //Act
        var entity = createGameDto.ToEntity();

        //Assert
        entity.Id.ShouldBeOfType<Guid>();
        entity.Title.ShouldBe(expectedResult.Title);
        entity.ReleaseDate.ShouldBe(expectedResult.ReleaseDate);
        entity.Cast.ShouldBe(expectedResult.Cast);
        entity.Crew.ShouldBe(expectedResult.Crew);
        entity.Directors.ShouldBe(expectedResult.Directors);
        entity.Writers.ShouldBe(expectedResult.Writers);
        entity.Genre.ShouldBe(expectedResult.Genre);
        entity.Platforms.ShouldBe(expectedResult.Platforms);
    }

    [Test]
    public void CreateGameDtoToEntity_WithCreateGameDtoMissingValues_ShouldReturnGameEntity()
    {
        //Arrange
        var dateTime = DateTime.Now;
        var createGameDto = new CreateGameDto
        {
            Title = "Title",
            Directors = "Directors",
            Writers = "Writers",
            Genre = 0,
            Platforms = 0
        };
        var expectedResult = new GameEntity
        {
            Title = "Title",
            Directors = "Directors",
            Writers = "Writers",
            Genre = 0,
            Platforms = 0
        };

        //Act
        var entity = createGameDto.ToEntity();

        //Assert
        entity.Id.ShouldBeOfType<Guid>();
        entity.Title.ShouldBe(expectedResult.Title);
        entity.ReleaseDate.ShouldBe(DateTime.MinValue);
        entity.Cast.ShouldBeNull();
        entity.Crew.ShouldBeNull();
        entity.Directors.ShouldBe(expectedResult.Directors);
        entity.Writers.ShouldBe(expectedResult.Writers);
        entity.Genre.ShouldBe(expectedResult.Genre);
        entity.Platforms.ShouldBe(expectedResult.Platforms);
    }

    [Test]
    public void GameEntityToDto_WithValidGameEntity_ShouldReturnGameDto()
    {
        //Arrange
        var dateTime = DateTime.Now;
        var gameEntity = new GameEntity
        {
            Title = "Title",
            ReleaseDate = dateTime,
            Cast = "Cast",
            Crew = "Crew",
            Directors = "Directors",
            Writers = "Writers",
            Genre = 0,
            Platforms = 0
        };
        var expectedResult = new GameDto
        {
            Title = "Title",
            ReleaseDate = dateTime,
            Cast = "Cast",
            Crew = "Crew",
            Directors = "Directors",
            Writers = "Writers",
            Genre = 0,
            Platforms = 0
        };

        //Act
        var dto = gameEntity.ToDto();

        //Assert
        dto.Id.ShouldBeOfType<Guid>();
        dto.Title.ShouldBe(expectedResult.Title);
        dto.ReleaseDate.ShouldBe(expectedResult.ReleaseDate);
        dto.Cast.ShouldBe(expectedResult.Cast);
        dto.Crew.ShouldBe(expectedResult.Crew);
        dto.Directors.ShouldBe(expectedResult.Directors);
        dto.Writers.ShouldBe(expectedResult.Writers);
        dto.Genre.ShouldBe(expectedResult.Genre);
        dto.Platforms.ShouldBe(expectedResult.Platforms);
    }
    //Game Entity/Dto END

    //Movie Entity/Dto START
    //Movie Entity/Dto END
}
