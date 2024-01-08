using HaadEdu.Domain.Entities;
using HaadEdu.Domain.Repositories;
using HaadEdu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Linq.Expressions;

namespace HaadEdu.Application.Repositories;

public class RolePermissionRepository(AppDbContext context, ILogger logger) : GenericRepository<RolePermission>(context, logger), IRolePermissionRepository
{
    public readonly ILogger _logger = logger;
    protected AppDbContext _context = context;
    internal DbSet<RolePermission> _dbSet = context.Set<RolePermission>();

    public virtual async Task<RolePermission> AddRolePermissionAsync(RolePermission rolePermission)
    {
        await _dbSet.AddAsync(rolePermission);
        return rolePermission;
    }

    public virtual async Task<bool> DeleteRolePermissionAsync(Expression<Func<RolePermission, bool>> expression)
    {
        var entityToDelete = await _dbSet.SingleOrDefaultAsync(expression);

        if (entityToDelete != null)
        {
            _dbSet.Remove(entityToDelete);
        }

        return true;
    }

    public virtual IQueryable<RolePermission> GetAllRolePermission(Expression<Func<RolePermission, bool>> expression, string[]? include = null, bool isTracking = true)
    {
        IQueryable<RolePermission> query = _dbSet;

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

    public virtual async Task<RolePermission?> GetRolePermissionAsync(Expression<Func<RolePermission, bool>> expression, string[]? include = null)
    {
        IQueryable<RolePermission> query = _dbSet;

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

    public virtual async Task<bool> UpdateRolePermission(RolePermission rolePermission)
    {
        _dbSet.Update(rolePermission);
        return true;
    }
}
