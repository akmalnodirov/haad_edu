using HaadEdu.Application.DTOs.Login;

namespace HaadEdu.Application.Services.Interfaces;
public interface ILogginService
{
    Task<LoginForView> LoginAsync(LoginForCreation loginForCreation);

}
