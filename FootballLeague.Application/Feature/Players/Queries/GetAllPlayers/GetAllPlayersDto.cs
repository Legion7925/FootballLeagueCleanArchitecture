using FootballLeague.Application.Common.Mappings;
using FootballLeague.Domain.Entities;

namespace FootballLeague.Application.Feature.Players.Queries.GetAllPlayers;

public class GetAllPlayersDto : IMapFrom<Player>
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public int ShirtNo { get; init; }
    public int HeightInCm { get; init; }
    public string FacebookUrl { get; init; } = string.Empty;
    public string TwitterUrl { get; init; } = string.Empty;
    public string InstagramUrl { get; init; } = string.Empty;
    public int DisplayOrder { get; init; }
}
