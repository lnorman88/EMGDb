﻿using EMGDb.Domain.Enums;

namespace EMGDb.Domain.DTOs.Media;
public abstract class MediaDto
{
    public Guid? Id { get; set; }
    public string? Cast { get; set; }
    public string? Crew { get; set; }
    public string? Directors { get; set; }
    public string? Writers { get; set; }
    public Genre? Genre { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string? Title { get; set; }
}
