using FootballLeague.Application.Common.Mappings;
using FootballLeague.Domain.Entities;

namespace FootballLeague.Application.Feature.Players.Queries.GetPlayersWithPagination;

public class GetPlayersWithPaginationDto : IMapFrom<Player>
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int ShirtNo { get; set; }
    public int HeightInCm { get; set; }
    public required string FacebookUrl { get; set; }
    public required string TwitterUrl { get; set; }
    public required string InstagramUrl { get; set; }
    public int DisplayOrder { get; set; }
}
