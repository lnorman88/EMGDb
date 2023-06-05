using EMGDb.Domain.Entities.Media;
using MediatR;

namespace EMGDb.Application.CQRS.Movie.CreateMovie
{
    public class CreateMovieQuery : IRequest<int>
    {
        public CreateMovieQuery(MovieEntity createMovieEntity)
        {
            CreateMovieEntity = createMovieEntity;
        }

        public MovieEntity CreateMovieEntity { get; }
    }
}
