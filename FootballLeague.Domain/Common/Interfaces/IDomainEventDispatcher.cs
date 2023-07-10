using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Domain.Common.Interfaces;

public interface IDomainEventDispatcher
{
    Task DispatcherAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents)
}
