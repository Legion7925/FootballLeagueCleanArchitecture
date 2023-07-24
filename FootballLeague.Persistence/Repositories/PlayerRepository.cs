using FootballLeague.Application.Interfaces.Repositories;
using FootballLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Persistence.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly IGenericRepository<Player> repository;

    public PlayerRepository(IGenericRepository<Player> repository)
    {
        this.repository = repository;
    }
    public async Task<IEnumerable<Player>> GetPlayersByClubId(int ClubId)
    {
        return await repository.Entities.Where(p => p.ClubId == ClubId).ToListAsync();
    }
}
