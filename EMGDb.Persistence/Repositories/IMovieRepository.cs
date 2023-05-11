using EMGDb.Domain.Entities.Media;
using EMGDb.Domain.Filters;

namespace EMGDb.Persistence.Repositorys
{
    public interface IMovieRepository
    {
        Task<int> CreateMovie(MovieEntity createMovieEntity, CancellationToken cancellationToken);
        Task<List<MovieEntity>> GetAllMovies(MovieFilter movieFilter);
        Task<int> DeleteMovieByIdAsync(Guid Id, CancellationToken cancellationToken);
    }
}