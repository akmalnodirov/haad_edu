using HaadEdu.Domain;

namespace HaadEdu.Application.Dtos.Role;

public class AddRoleRequest
{
    public required string Name { get; set; }
    public ICollection<Permissions> RolePermissions { get; set; } = new List<Permissions>();
}
