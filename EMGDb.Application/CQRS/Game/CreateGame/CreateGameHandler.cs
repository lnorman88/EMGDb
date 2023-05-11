using EMGDb.Persistence.Repositorys;
using MediatR;

namespace EMGDb.Application.CQRS.Game.CreateGame;
public class CreateGameHandler : IRequestHandler<CreateGameQuery, int>
{
    public CreateGameHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    private IGameRepository _gameRepository { get; }

    public Task<int> Handle(CreateGameQuery request, CancellationToken cancellationToken)
    {
        var result = _gameRepository.CreateGameAsync(request.CreateGameEntity, cancellationToken);

        return result;
    }
}
