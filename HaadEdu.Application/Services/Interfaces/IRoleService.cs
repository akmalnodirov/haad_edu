using HaadEdu.Application.Dtos.Role;
using HaadEdu.Application.Result;
using HaadEdu.Domain.Entities;
using System.Linq.Expressions;

namespace HaadEdu.Application.Services.Interfaces;

public interface IRoleService
{
    Task<Role?> GetRoleAsync(Expression<Func<Role, bool>> expression, string[]? include = null);
    Task<IEnumerable<Role>> GetAllRolesAsync(Expression<Func<Role, bool>> expression, string[]? include = null, bool isTracking = true);
    Task<Result<AddRoleResponse>> CreateRoleAsync(AddRoleRequest request);
    Task<bool> UpdateRoleAsync(Role entity);
    Task<bool> DeleteRoleAsync(Expression<Func<Role, bool>> expression);

}
