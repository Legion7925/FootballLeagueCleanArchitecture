using FootballLeague.Application.Interfaces.Repositories;
using FootballLeague.Domain.Common;
using FootballLeague.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace FootballLeague.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbcontext;
    private Hashtable _repositories;
    private bool _disposed;

    public UnitOfWork(ApplicationDbContext context)
    {
        _dbcontext = context;
        _repositories = new();
    }

    public IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity
    {
        var type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(GenericRepository<>);

            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)) , _dbcontext);

            _repositories.Add(type, repositoryInstance);
        }

        return (IGenericRepository<T>)_repositories[type]!;
    }

    public Task Rollback()
    {
        _dbcontext.ChangeTracker.Entries().ToList().ForEach(x=> x.Reload());
        return Task.CompletedTask;
    }

    public async Task<int> Save(CancellationToken cancellationToken)
    {
         return await _dbcontext.SaveChangesAsync(cancellationToken);
    }

    public Task<int> SaveAndRemoveCahche(CancellationToken cancellationToken, params string[] cacheKeys)
    {
        throw new NotImplementedException();
    }
}
