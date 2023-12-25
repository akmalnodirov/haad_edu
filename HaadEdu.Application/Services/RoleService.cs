using AutoMapper;
using HaadEdu.Application.Services.Interfaces;
using HaadEdu.Domain.Entities;
using HaadEdu.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HaadEdu.Application.Services;

public class RoleService(IUnitOfWork unitOfWork, IMapper mapper) : BaseService(unitOfWork, mapper), IRoleService
{

    public async Task<Role> CreateRoleAsync(Role entity)
    {
        var result = await _unitOfWork.RoleRepository.CreateAsync(entity);
        await _unitOfWork.CompleteAsync();
        return result;
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
