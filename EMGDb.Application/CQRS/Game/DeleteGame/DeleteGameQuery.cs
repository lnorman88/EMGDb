using MediatR;

namespace EMGDb.Application.CQRS.Game.DeleteGame;
public class DeleteGameQuery : IRequest<int>
{
    public DeleteGameQuery(Guid gameId)
    {
        GameId = gameId;
    }

    public Guid GameId { get; }
}
