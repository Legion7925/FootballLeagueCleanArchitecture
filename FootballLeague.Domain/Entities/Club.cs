using FootballLeague.Domain.Common;

namespace FootballLeague.Domain.Entities;

public class Club : BaseAuditableEntity
{
    public required string Name { get; set; }
    public string? PhotoUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? FacebookUrl { get; set; }
    public string? TwitterUrl { get; set; }
    public string? YoutubeUrl { get; set; }
    public string? InstagramUrl { get; set; }
    public int? StadiumId { get; set; }
    public ICollection<Player> Players { get; set; } = new List<Player>();
    public Staduim? Staduim { get; set; }
}
