using Coursera.Extensions;
using Coursera.Models;
using Coursera.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;

namespace Coursera.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    /// <summary>
    /// The main context
    /// </summary>
    private readonly MainContext _mainContext;

    private readonly string HashKey = "pass_hash";

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
    /// </summary>
    /// <param name="mainContext">The main context.</param>
    public AuthenticationController(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    /// <summary>
    /// Logins the specified login request.
    /// </summary>
    /// <param name="loginRequest">The login request.</param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login(Login loginRequest)
    {
        var user = _mainContext.Users.FirstOrDefault(u => u.Name == loginRequest.Username);

        if (user == null)
        {
            return NotFound();
        }

        if (user.Password != loginRequest.Password + HashKey)
        {
            return Unauthorized();
        }

        var userRoles = await _mainContext
            .UserRoles
            .Include(ur => ur.Role)
            .Where(ur => ur.User.Id == user.Id).ToListAsync();

        var claims = new List<Claim> {
            new(ClaimTypes.Name, user.Name),
            new("userPassword", user.Email),
            new("userId", user.Id.ToString()),
            new("company", "LearningCenter"),
           // new("roleId", user.RoleId)
    };

        foreach (var item in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, item.Role.Name));
        }

        var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.Now.Add(TimeSpan.FromSeconds(10)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
    }

    /// <summary>
    /// Signs up.
    /// </summary>
    /// <param name="signupRequest">The signup request.</param>
    /// <returns></returns>
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(User signupRequest)
    {

        var user = new User
        {
            Email = signupRequest.Email,
            Name = signupRequest.Name,
            Password = signupRequest.Password + HashKey,
        };

        await _mainContext.Users.AddAsync(user);
        await _mainContext.SaveChangesAsync();

        return Ok(new { user.Email, user.Name });
    }


    [HttpPost("claims")]
    //[Authorize(Policy = "OnlyForHaad")]
    [Authorize(Roles = "OnlyForHaad")]
    public async Task<IActionResult> Claims()
    {
        var s = User;

        var h = User.Claims;

        s.FindAll(c => c.Value == "userPassword");
        var hh = new ClaimsIdentity();


        return Ok();

    }

    [HttpPost("AddUserRole")]
    public async Task<IActionResult> AddRole(UserRoleAddRequest userRoleAddRequest)
    {
        var role = await _mainContext.Roles.FirstOrDefaultAsync(r => r.Id == userRoleAddRequest.RoleId);
        var user = await _mainContext.Users.FirstOrDefaultAsync(u => u.Id == userRoleAddRequest.UserId);
        var userRole = new UserRole
        {
            Role = role,
            User = user
        };

        await _mainContext.UserRoles.AddAsync(userRole);
        await _mainContext.SaveChangesAsync();

        return Created();
    }

    [HttpPost("AddRole")]
    public async Task<IActionResult> AddRole(Role role)
    {
        await _mainContext.Roles.AddAsync(role);
        await _mainContext.SaveChangesAsync();
        return Created();
    }
}
