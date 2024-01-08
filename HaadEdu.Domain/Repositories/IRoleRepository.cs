using HaadEdu.Domain.Entities;
using System.Linq.Expressions;

namespace HaadEdu.Domain.Repositories;

public interface IRoleRepository : IGenericRepository<Role>
{
    Task<Role> AddRoleAsync(Role role);
    Task<bool> DeleteRoleAsync(Expression<Func<Role, bool>> expression);
    Task<bool> UpdateRole(Role role);
    Task<Role?> GetRoleAsync(Expression<Func<Role, bool>> expression, string[]? include = null);
    IQueryable<Role> GetAllRole(Expression<Func<Role, bool>> expression,
        string[]? include = null,
        bool isTracking = true);
}
