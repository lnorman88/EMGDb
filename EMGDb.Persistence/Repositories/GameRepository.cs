using EMGDb.Domain.Entities.Media;
using EMGDb.Domain.Filters;
using EMGDb.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EMGDb.Persistence.Repositorys
{
    public class GameReposiroty : IGameRepository
    {
        private readonly IApplicationDbContext _context;
        public GameReposiroty(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<int> CreateGameAsync(GameEntity createGameEntity, CancellationToken cancellationToken)
        {
            await _context.Game.AddAsync(createGameEntity);
            var result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }

        public async Task<List<GameEntity>> GetGamesAsync(GameFilter gameFilter)
        {
            var query = CreateQueryFromFilter(_context.Game.AsQueryable(), gameFilter);

            return await query.ToListAsync();
        }

        public async Task<int> DeleteGameByIdAsync(Guid Id, CancellationToken cancellationToken)
        {
            var gameEntity = new GameEntity { Id = Id };
            _context.Game.Remove(gameEntity);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        private IQueryable<GameEntity> CreateQueryFromFilter(IQueryable<GameEntity> query, GameFilter gameFilter)
        {
            if (gameFilter == null)
                return query;

            if (!string.IsNullOrEmpty(gameFilter.Id))
                query = query.Where(x => x.Id.ToString().ToLower().Contains(gameFilter.Id.ToLower()));

            if (!string.IsNullOrEmpty(gameFilter.Crew))
                query = query.Where(x => x.Crew!.ToLower().Contains(gameFilter.Crew.ToLower()));

            if (!string.IsNullOrEmpty(gameFilter.Cast))
                query = query.Where(x => x.Cast!.ToLower().Contains(gameFilter.Cast.ToLower()));

            if (!string.IsNullOrEmpty(gameFilter.Directors))
                query = query.Where(x => x.Directors!.ToLower().Contains(gameFilter.Directors.ToLower()));

            if (!string.IsNullOrEmpty(gameFilter.Writers))
                query = query.Where(x => x.Writers!.ToLower().Contains(gameFilter.Writers.ToLower()));

            if (!string.IsNullOrEmpty(gameFilter.Title))
                query = query.Where(x => x.Title!.ToLower().Contains(gameFilter.Title.ToLower()));

            if (gameFilter.ReleaseDate.HasValue)
                query = query.Where(x => x.ReleaseDate == gameFilter.ReleaseDate);

            if (Int32.TryParse(gameFilter.Genre, out int genre))
                query = query.Where(x => Convert.ToInt32(x.Genre) == genre);

            if (Int32.TryParse(gameFilter.Platforms, out int platform))
                query = query.Where(x => Convert.ToInt32(x.Platforms) == platform);

            return query;
        }
    }
}
