using EMGDb.Persistence.Repositorys;
using MediatR;

namespace EMGDb.Application.CQRS.Movie.CreateMovie
{
    public class CreateMovieEntryHandler : IRequestHandler<CreateMovieEntryQuery, int>
    {
        private readonly IMovieRepository _movieRepository;
        public CreateMovieEntryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Task<int> Handle(CreateMovieEntryQuery request, CancellationToken cancellationToken)
        {
            var result = _movieRepository.CreateMovie(request.CreateMovieEntity, cancellationToken);

            return result;
        }
    }
}
