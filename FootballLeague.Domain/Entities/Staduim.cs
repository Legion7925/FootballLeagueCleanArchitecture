using FootballLeague.Domain.Common;

namespace FootballLeague.Domain.Entities;

public class Staduim : BaseAuditableEntity
{
    public required string Name { get; set; }
    public string? PhotoUrl { get; set; }
    public int? Capacity { get; set; }
    public int? BuiltYear { get; set; }
    public int? PitchLength { get; set; }
    public int? PitchWidth { get; set; }
    public required string Phone { get; set; }
    public required string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? AddressLine3 { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public int? CountryId { get; set; }
    public Country? Country { get; set; }
    public ICollection<Club> Clubs { get; set; } = new List<Club>();
}
