using EMGDb.Domain.Entities.Media;
using EMGDb.Domain.Filters;
using EMGDb.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EMGDb.Persistence.Repositorys;

public class MovieRepository : IMovieRepository
{
    private readonly IApplicationDbContext _context;

    public MovieRepository(IApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    public async Task<int> CreateMovie(MovieEntity createMovieEntity, CancellationToken cancellationToken)
    {
        await _context.Movie.AddAsync(createMovieEntity);
        var result = await _context.SaveChangesAsync(cancellationToken);

        return result;
    }

    public async Task<List<MovieEntity>> GetAllMovies(MovieFilter movieFilter)
    {
        var query = CreateQueryFromFilter(_context.Movie.AsQueryable(), movieFilter);

        return await query.ToListAsync();
    }

    public async Task<int> DeleteMovieByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        var movieEntity = new MovieEntity { Id = Id };
        _context.Movie.Remove(movieEntity);
        return await _context.SaveChangesAsync(cancellationToken);
    }

    private IQueryable<MovieEntity> CreateQueryFromFilter(IQueryable<MovieEntity> query, MovieFilter movieFilter)
    {
        if (movieFilter == null)
            return query;

        if (!string.IsNullOrEmpty(movieFilter.Id))
            query = query.Where(x => x.Id.ToString().ToLower().Contains(movieFilter.Id.ToLower()));

        if (!string.IsNullOrEmpty(movieFilter.Crew))
            query = query.Where(x => x.Crew!.ToLower().Contains(movieFilter.Crew.ToLower()));

        if (!string.IsNullOrEmpty(movieFilter.Cast))
            query = query.Where(x => x.Cast!.ToLower().Contains(movieFilter.Cast.ToLower()));

        if (!string.IsNullOrEmpty(movieFilter.Directors))
            query = query.Where(x => x.Directors!.ToLower().Contains(movieFilter.Directors.ToLower()));

        if (!string.IsNullOrEmpty(movieFilter.Writers))
            query = query.Where(x => x.Writers!.ToLower().Contains(movieFilter.Writers.ToLower()));

        if (!string.IsNullOrEmpty(movieFilter.Title))
            query = query.Where(x => x.Title!.ToLower().Contains(movieFilter.Title.ToLower()));

        if (movieFilter.ReleaseDate.HasValue)
            query = query.Where(x => x.ReleaseDate == movieFilter.ReleaseDate);

        if (Int32.TryParse(movieFilter.Genre, out int genre))
            query = query.Where(x => Convert.ToInt32(x.Genre) == genre);

        if (!string.IsNullOrEmpty(movieFilter.Runtime))
            query = query.Where(x => x.Title!.ToLower().Contains(movieFilter.Runtime.ToLower()));

        return query;
    }
}