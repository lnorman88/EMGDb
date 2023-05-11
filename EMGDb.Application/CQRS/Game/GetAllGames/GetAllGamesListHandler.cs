using EMGDb.Domain.Entities.Media;
using EMGDb.Persistence.Repositorys;
using MediatR;

namespace EMGDb.Application.CQRS.Game.GetAllGames
{
    public class GetAllGamesListHandler : IRequestHandler<GetAllGamesQuery, List<GameEntity>>
    {
        private readonly IGameRepository _gameRepository;

        public GetAllGamesListHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public Task<List<GameEntity>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            var result = _gameRepository.GetGamesAsync(request.GameFilter);

            return result;
        }
    }
}
