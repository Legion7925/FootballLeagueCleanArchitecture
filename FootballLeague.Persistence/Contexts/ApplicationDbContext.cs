using FootballLeague.Domain.Common;
using FootballLeague.Domain.Common.Interfaces;
using FootballLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FootballLeague.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    private readonly IDomainEventDispatcher _dispatcher;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options , IDomainEventDispatcher dispatcher)
        :base (options)
    {
        _dispatcher = dispatcher;
    }

    public DbSet<Player> players => Set<Player>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //when writing this line you don't have to do the configuration here 
        //you can write the entity configuration in other classes and modelbuilder 
        //will find the classes because you wrote this line
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

        if(_dispatcher is null) return result;

        var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
            .Select(e => e.Entity)
            .Where(e=> e.DomainEvents.Any())
            .ToArray();

        await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
