using HaadEdu.Domain;

namespace HaadEdu.Application.Dtos.Role;

public class AddRoleResponse
{
    public long RoleId { get; set; }
    public required string Name { get; set; }
    public ICollection<Permissions> RolePermissions { get; set; } = new List<Permissions>();
}
