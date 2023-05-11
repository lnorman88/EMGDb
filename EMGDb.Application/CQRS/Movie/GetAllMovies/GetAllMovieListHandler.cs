using EMGDb.Domain.Entities.Media;
using EMGDb.Persistence.Repositorys;
using MediatR;

namespace EMGDb.Application.CQRS.Movie.GetAllMovies
{
    public class GetAllMovieListHandler : IRequestHandler<GetAllMoviesQuery, List<MovieEntity>>
    {
        private readonly IMovieRepository _movieRepository;
        public GetAllMovieListHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public Task<List<MovieEntity>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var result = _movieRepository.GetAllMovies(request.MovieFilter);

            return result;
        }
    }
}
