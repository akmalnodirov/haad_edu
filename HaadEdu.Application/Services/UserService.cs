using HaadEdu.Application.Dtos.UserDTOs;
using HaadEdu.Application.Services.Interfaces;
using HaadEdu.Domain.Entities;
using System.Linq.Expressions;

namespace HaadEdu.Application.Services;

public class UserService : IUserServace  
{

    public Task<UserForView> CreateAsync(UserForCreation userForCreationDTO)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserForView>> GetAllAsync(PaginationParams @params, Expression<Func<User, bool>> expression = null)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserForView>> GetAllByCourse(PaginationParams paginationParams, string CourceName)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetAsync(Expression<Func<User, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<UserForView> UpdateAsync(int id, UserForUpdate userForUpdtae)
    {
        throw new NotImplementedException();
    }
    public Task<bool> ChangeRoleAsync(int id, Role userRole)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangePasswordAsync(UserForchangePassword userForChangePasswordDTO)
    {
        throw new NotImplementedException();
    }
}
