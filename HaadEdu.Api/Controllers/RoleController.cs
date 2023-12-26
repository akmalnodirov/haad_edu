using HaadEdu.Application.Dtos.Role;
using HaadEdu.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HaadEdu.Api.Controllers;

public class RoleController(IRoleService roleService) : BaseController
{
    private readonly IRoleService _roleService = roleService;

    [HttpGet]
    [Route("{roleId:long}")]
    public async Task<IActionResult> GetRoleAsync(long roleId)
    {
        var role = await _roleService.GetRoleAsync(role => role.Id == roleId);

        if (role == null)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddRoleAsync(AddRoleRequest addRoleRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var role = await _roleService.CreateRoleAsync(addRoleRequest);

        if (role == null)
        {
            return NotFound();
        }

        return Ok(role);
    }
}
