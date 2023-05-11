namespace EMGDb.Domain.Filters;
public class MovieFilter
{
    public string? Id { get; set; }
    public string? Cast { get; set; }
    public string? Crew { get; set; }
    public string? Directors { get; set; }
    public string? Genre { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string? Title { get; set; }
    public string? Writers { get; set; }
    public string? Runtime { get; set; }
}
