using HaadEdu.Domain.Entities;
using HaadEdu.Domain.Repositories;
using HaadEdu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Linq.Expressions;

namespace HaadEdu.Application.Repositories;

public class RoleRepository(AppDbContext context, ILogger logger) : GenericRepository<Role>(context, logger), IRoleRepository
{
    public readonly ILogger _logger = logger;
    protected AppDbContext _context = context;
    internal DbSet<Role> _dbSet = context.Set<Role>();
    public virtual async Task<Role> AddRoleAsync(Role role)
    {
        await _dbSet.AddAsync(role);
        return role;
    }

    public virtual async Task<bool> DeleteRoleAsync(Expression<Func<Role, bool>> expression)
    {
        var entityToDelete = await _dbSet.SingleOrDefaultAsync(expression);

        if (entityToDelete != null)
        {
            _dbSet.Remove(entityToDelete);
        }

        return true;
    }

    public virtual IQueryable<Role> GetAllRole(Expression<Func<Role, bool>> expression, string[]? include = null, bool isTracking = true)
    {
        IQueryable<Role> query = _dbSet;

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

    public virtual async Task<Role?> GetRoleAsync(Expression<Func<Role, bool>> expression, string[]? include = null)
    {
        IQueryable<Role> query = _dbSet;

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

    public virtual async Task<bool> UpdateRole(Role role)
    {
        _dbSet.Update(role);
        return true;
    }
}
