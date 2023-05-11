using EMGDb.Domain.Enums;

namespace EMGDb.WebApi.DTOs
{
    public class CreateGameDto
    {
        public string Cast { get; set; }
        public string Crew { get; set; }
        public string Directors { get; set; }
        public string Writers { get; set; }
        public Genre Genre { get; set; } // Enum
        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; }
        public GamePlatform Platforms { get; set; } // Enum
    }
}
