using FootballLeague.Domain.Entities;

namespace FootballLeague.Application.Interfaces.Repositories;

public interface IPlayerRepository
{
    Task<IEnumerable<Player>> GetPlayersByClubId(int ClubId);
}
