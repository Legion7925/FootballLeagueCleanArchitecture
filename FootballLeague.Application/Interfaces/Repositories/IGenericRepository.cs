using FootballLeague.Domain.Common.Interfaces;

namespace FootballLeague.Application.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class, IEntity
{
    IQueryable<T> Entities { get; }

    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
