using EMGDb.Domain.Entities.Media;
using MediatR;

namespace EMGDb.Application.CQRS.Game.CreateGame;
public class CreateGameQuery : IRequest<int>
{
    public CreateGameQuery(GameEntity createGameEntity)
    {
        CreateGameEntity = createGameEntity;
    }

    public GameEntity CreateGameEntity { get; }
}
