using EMGDb.Domain.DTOs;
using EMGDb.Domain.DTOs.Media;
using EMGDb.Domain.Entities.Media;
using EMGDb.WebApi.DTOs;

namespace EMGDb.WebApi.Helpers
{
    public static class DtoExtentions
    {
        //Game Entity/Dto Start
        public static GameEntity ToEntity(this CreateGameDto dto)
        {
            return new GameEntity
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                ReleaseDate = dto.ReleaseDate,
                Cast = dto.Cast,
                Crew = dto.Crew,
                Directors = dto.Directors,
                Genre = dto.Genre,
                Platforms = dto.Platforms,
                Writers = dto.Writers
            };
        }

        public static GameDto ToDto(this GameEntity entity)
        {
            return new GameDto
            {
                Id = entity.Id,
                Title = entity.Title,
                ReleaseDate = entity.ReleaseDate,
                Cast = entity.Cast,
                Crew = entity.Crew,
                Directors = entity.Directors,
                Genre = entity.Genre,
                Platforms = entity.Platforms,
                Writers = entity.Writers
            };
        }
        //Game Entity/Dto End

        //Movie Entity/Dto Start
        public static MovieEntity ToEntity(this CreateMovieDto dto)
        {
            return new MovieEntity()
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                ReleaseDate = dto.ReleaseDate,
                Cast = dto.Cast,
                Crew = dto.Crew,
                Directors = dto.Directors,
                Genre = dto.Genre,
                Runtime = dto.Runtime,
                Writers = dto.Writers
            };
        }

        public static MovieDto ToDto(this MovieEntity entity)
        {
            return new MovieDto()
            {
                Id = entity.Id,
                Title = entity.Title,
                ReleaseDate = entity.ReleaseDate,
                Cast = entity.Cast,
                Crew = entity.Crew,
                Directors = entity.Directors,
                Genre = entity.Genre,
                Runtime = entity.Runtime,
                Writers = entity.Writers
            };
        }
        //Movie Entity/Dto End
    }
}
