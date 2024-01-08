using HaadEdu.Domain.Entities;
using System.Linq.Expressions;

namespace HaadEdu.Domain.Repositories;

public interface IRolePermissionRepository : IGenericRepository<RolePermission>
{
    Task<RolePermission> AddRolePermissionAsync(RolePermission rolePermission);
    Task<bool> DeleteRolePermissionAsync(Expression<Func<RolePermission, bool>> expression);
    Task<bool> UpdateRolePermission(RolePermission rolePermission);
    Task<RolePermission?> GetRolePermissionAsync(Expression<Func<RolePermission, bool>> expression, string[]? include = null);
    IQueryable<RolePermission> GetAllRolePermission(Expression<Func<RolePermission, bool>> expression,
        string[]? include = null,
        bool isTracking = true);
}
