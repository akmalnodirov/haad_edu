using HaadEdu.Domain.Entities;
using HaadEdu.Domain.Repositories;
using HaadEdu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace HaadEdu.Application.Repositories;

public class GenericRepository<T>(AppDbContext context, ILogger logger) : IGenericRepository<T> where T : BaseEntity
{
    public readonly ILogger _logger = logger;
    protected AppDbContext _context = context;
    internal DbSet<T> _dbSet = context.Set<T>();

    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    /// <summary>
    /// Adds the range asynchronous.
    /// </summary>
    /// <param name="entities">The entities.</param>
    public virtual async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <returns></returns>
    public virtual async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
    {
        var entityToDelete = await _dbSet.SingleOrDefaultAsync(expression);

        if (entityToDelete != null)
        {
            _dbSet.Remove(entityToDelete);
        }

        return true;
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="include">The include.</param>
    /// <param name="isTracking">if set to <c>true</c> [is tracking].</param>
    /// <returns></returns>
    public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> expression, string[]? include = null, bool isTracking = true)
    {
        IQueryable<T> query = _dbSet;

        if (expression != null)
        {
            query = query.Where(expression);
        }

        if (include != null)
        {
            foreach (var navigationProperty in include)
            {
                query = query.Include(navigationProperty);
            }
        }

        if (!isTracking)
        {
            query = query.AsNoTracking();
        }

        return query;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="include"></param>
    /// <returns></returns>
    public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> expression, string[]? include = null)
    {
        IQueryable<T> query = _dbSet;

        query = query.Where(expression);

        if (include != null)
        {
            foreach (var navigationProperty in include)
            {
                query = query.Include(navigationProperty);
            }
        }

        var r = await query.FirstOrDefaultAsync();
        return r;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual async Task<bool> Update(T entity)
    {
        _dbSet.Update(entity);
        return true;
    }
}
