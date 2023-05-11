using EMGDb.Persistence.Repositorys;
using MediatR;

namespace EMGDb.Application.CQRS.Movie.DeleteMovie;
public class DeleteMovieHandler : IRequestHandler<DeleteMovieQuery, int>
{
    private readonly IMovieRepository _movieRepository;

    public DeleteMovieHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    public async Task<int> Handle(DeleteMovieQuery request, CancellationToken cancellationToken)
    {
        var result = await _movieRepository.DeleteMovieByIdAsync(request.MovieId, cancellationToken);

        return result;
    }
}
