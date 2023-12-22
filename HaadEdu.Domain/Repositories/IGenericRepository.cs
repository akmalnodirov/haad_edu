using HaadEdu.Domain.Entities;
using System.Linq.Expressions;

namespace HaadEdu.Domain.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    public Task<T> CreateAsync(T entity);
    public Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
    public Task<T> UpdateAsync(T entity);
    public Task<T> GetAsync(Expression<Func<T, bool>> expression, string[] include = null);
    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression,
        string[] include = null,
        bool isTracking = true);
    public Task SaveChangesAsync();
}
