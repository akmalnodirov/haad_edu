using AutoMapper;
using HaadEdu.Application.Dtos.Role;
using HaadEdu.Application.Result;
using HaadEdu.Application.Services.Interfaces;
using HaadEdu.Domain;
using HaadEdu.Domain.Entities;
using HaadEdu.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Linq.Expressions;

namespace HaadEdu.Application.Services;

public class RoleService(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer<AppLanguage> localizer) : BaseService(unitOfWork, mapper, localizer), IRoleService
{
    public async Task<Result<AddRoleResponse>> CreateRoleAsync(AddRoleRequest addRoleRequest)
    {
        await _unitOfWork.BeginTransaction();
        try
        {
            var validPermissions = Enum.GetValues(typeof(Permissions)).Cast<Permissions>();
            if (addRoleRequest.RolePermissions.Except(validPermissions).Any())
            {
                return new Result<AddRoleResponse>(ErrorMessages.InvalidPermission);
            }

            var role = new Role { Name = addRoleRequest.Name };
            await _unitOfWork.RoleRepository.AddAsync(role);
            await _unitOfWork.CompleteAsync();

            var rolePermissionsToAdd = addRoleRequest.RolePermissions
                .Select(item => new RolePermission { RoleId = role.Id, Permission = item })
                .ToList();
            await _unitOfWork.RolePermissionRepository.AddRangeAsync(rolePermissionsToAdd);
            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            var result = new AddRoleResponse { RoleId = role.Id, Name = addRoleRequest.Name, RolePermissions = addRoleRequest.RolePermissions };
            return new Result<AddRoleResponse>(result);
        }
        catch (Exception)
        {
            await _unitOfWork.RollBackAsync();
            throw;
        }
    }

    public async Task<bool> DeleteRoleAsync(Expression<Func<Role, bool>> expression)
    {
        var result = await _unitOfWork.RoleRepository.DeleteAsync(expression);
        await _unitOfWork.CompleteAsync();
        return result;
    }

    public async Task<IEnumerable<Role>> GetAllRolesAsync(Expression<Func<Role, bool>> expression, string[]? include = null, bool isTracking = true)
    {
        var result = _unitOfWork.RoleRepository.GetAll(expression, include, isTracking);
        return await result.ToListAsync();
    }

    public async Task<Role?> GetRoleAsync(Expression<Func<Role, bool>> expression, string[]? include = null)
    {
        var r = await _unitOfWork.RoleRepository.GetAsync(expression, include);
        return r;
    }

    public async Task<bool> UpdateRoleAsync(Role entity)
    {
        var result = await _unitOfWork.RoleRepository.Update(entity);
        await _unitOfWork.CompleteAsync();
        return result;
    }
}
