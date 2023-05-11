using EMGDb.Domain.Enums;

namespace EMGDb.Domain.Entities.Media;

public class GameEntity : MediaEntity
{
    public GamePlatform? Platforms { get; set; }
}