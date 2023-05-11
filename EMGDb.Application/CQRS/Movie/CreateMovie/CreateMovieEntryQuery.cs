using EMGDb.Domain.Entities.Media;
using MediatR;

namespace EMGDb.Application.CQRS.Movie.CreateMovie
{
    public class CreateMovieEntryQuery : IRequest<int>
    {
        public CreateMovieEntryQuery(MovieEntity createMovieEntity)
        {
            CreateMovieEntity = createMovieEntity;
        }

        public MovieEntity CreateMovieEntity { get; }
    }
}
