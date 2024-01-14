using HaadEdu.Application.Dtos.UserDTOs;
using HaadEdu.Domain.Entities;
using System.Linq.Expressions;

namespace HaadEdu.Application.Services.Interfaces;

public interface IUserServace
{
    Task<UserForView> CreateAsync(UserForCreation userForCreationDTO);

    Task<UserForView> UpdateAsync(int id,  UserForUpdate userForUpdtae);

    Task<bool> DeleteAsync(int id);

    Task<IEnumerable<UserForView>> GetAllAsync(
        PaginationParams @params,
        Expression<Func<User, bool>> expression = null);

    Task<IEnumerable<UserForView>> GetAllByCourse(PaginationParams paginationParams, string CourceName );

    Task<User> GetAsync(Expression<Func<User, bool>> expression);

    Task<bool> ChangeRoleAsync(int id, Role userRole);

    Task<bool> ChangePasswordAsync(UserForchangePassword userForChangePasswordDTO);
} 