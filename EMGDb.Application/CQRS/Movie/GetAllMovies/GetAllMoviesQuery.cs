using EMGDb.Domain.Entities.Media;
using EMGDb.Domain.Filters;
using MediatR;

namespace EMGDb.Application.CQRS.Movie.GetAllMovies
{
    public class GetAllMoviesQuery : IRequest<List<MovieEntity>>
    {
        public GetAllMoviesQuery(MovieFilter movieFilter)
        {
            MovieFilter = movieFilter;
        }

        public MovieFilter MovieFilter;
    }
}
