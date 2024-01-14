using HaadEdu.Application.DTOs.Login;
using HaadEdu.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HaadEdu.Api.Controllers.Logins;
public class LoginController(ILogginService logginService) : BaseController
{
    private readonly ILogginService _logginService = logginService;
    
    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateAsync(LoginForCreation dto)
    {
        return Ok(new
        {
            Code = 200,
            Message = "Success",
            Data = await _logginService.LoginAsync(dto)
        }); 
    }    
}
