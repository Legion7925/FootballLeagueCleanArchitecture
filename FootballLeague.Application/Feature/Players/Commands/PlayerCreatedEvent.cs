using FootballLeague.Domain.Common;
using FootballLeague.Domain.Entities;

namespace FootballLeague.Application.Feature.Players.Commands;

public class PlayerCreatedEvent : BaseEvent
{
    public Player Player { get; }

    public PlayerCreatedEvent(Player player)
    {
        Player = player;
    }
}
