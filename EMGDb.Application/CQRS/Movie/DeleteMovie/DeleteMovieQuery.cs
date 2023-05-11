using MediatR;

namespace EMGDb.Application.CQRS.Movie.DeleteMovie;
public class DeleteMovieQuery : IRequest<int>
{
    public DeleteMovieQuery(Guid movieId)
    {
        MovieId = movieId;
    }

    public Guid MovieId { get; }
}
