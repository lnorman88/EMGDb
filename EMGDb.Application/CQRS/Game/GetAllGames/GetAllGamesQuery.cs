using EMGDb.Domain.Entities.Media;
using EMGDb.Domain.Filters;
using MediatR;

namespace EMGDb.Application.CQRS.Game.GetAllGames
{
    public class GetAllGamesQuery : IRequest<List<GameEntity>>
    {
        public GetAllGamesQuery(GameFilter gameFilter)
        {
            GameFilter = gameFilter;
        }

        public GameFilter GameFilter { get; }
    }
}
