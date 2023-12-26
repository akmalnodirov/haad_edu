using HaadEdu.Domain.Entities;
using System.Linq.Expressions;

namespace HaadEdu.Domain.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
    Task<bool> Update(T entity);
    Task<T?> GetAsync(Expression<Func<T, bool>> expression, string[]? include = null);
    IQueryable<T> GetAll(Expression<Func<T, bool>> expression,
        string[]? include = null,
        bool isTracking = true);
}
