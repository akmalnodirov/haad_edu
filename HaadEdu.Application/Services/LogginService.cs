using HaadEdu.Application.Dtos.UserDTOs;
using HaadEdu.Application.DTOs.Login;
using HaadEdu.Application.Extension;
using HaadEdu.Application.HaadEduException;
using HaadEdu.Application.Services.Interfaces;
using HaadEdu.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HaadEdu.Application.Services;
public class LogginService(IUserServace userServace, IConfiguration configuration, IRoleService role) : ILogginService
{
    private readonly IConfiguration configuration = configuration;
    private readonly IUserServace userServace = userServace;
    private readonly IRoleService roleService = role;

    public async Task<LoginForView> LoginAsync(LoginForCreation loginForCreation)
    {
        var userPassword = PasswordHashing.Encrypt(loginForCreation.Password);
        
        var user = await userServace.GetAsync(u => u.Email == loginForCreation.Email && u.Password == userPassword);
        
        if(user == null)
            throw new CustomException(400, "Email or password is incorrect");

        return new LoginForView
        {
            Token = GenerateToken(user)
        };
    }

    private string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                 new Claim("Id", user.Id.ToString()),
                 new Claim(ClaimTypes.Role, user.Role.Name.ToString()),
                 new Claim(ClaimTypes.Name, user.Firstname)
            }),
            Audience = configuration["JWT:Audience"],
            Issuer = configuration["JWT:Issuer"],
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(configuration["JWT:Expire"])),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
