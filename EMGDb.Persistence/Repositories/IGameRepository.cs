using EMGDb.Domain.Entities.Media;
using EMGDb.Domain.Filters;

namespace EMGDb.Persistence.Repositorys
{
    public interface IGameRepository
    {
        Task<int> CreateGameAsync(GameEntity createGameEntity, CancellationToken cancellationToken);
        Task<List<GameEntity>> GetGamesAsync(GameFilter gameFilter);
        Task<int> DeleteGameByIdAsync(Guid Id, CancellationToken cancellationToken);
    }
}