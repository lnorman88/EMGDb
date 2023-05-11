using EMGDb.Persistence.Repositorys;
using MediatR;

namespace EMGDb.Application.CQRS.Game.DeleteGame;
public class DeleteGameHandler : IRequestHandler<DeleteGameQuery, int>
{
    private readonly IGameRepository _gameRepository;

    public DeleteGameHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }
    public async Task<int> Handle(DeleteGameQuery request, CancellationToken cancellationToken)
    {
        var result = await _gameRepository.DeleteGameByIdAsync(request.GameId, cancellationToken);

        return result;
    }
}
