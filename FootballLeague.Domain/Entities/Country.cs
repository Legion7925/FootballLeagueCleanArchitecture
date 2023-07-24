using FootballLeague.Domain.Common;

namespace FootballLeague.Domain.Entities;

public class Country : BaseAuditableEntity
{
    public required string Name { get; set; }
    public string? TwoLetterIsoCode { get; set; }
    public string? ThreeLetterIsoCode { get; set; }
    public string? FlagUrl { get; set; }
    public int? DisplayOrder { get; set; }

    public ICollection<Staduim> Staduims { get; set; }= new List<Staduim>();
    public ICollection<Player> Players { get; set; } = new List<Player>();
}
