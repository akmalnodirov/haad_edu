namespace HaadEdu.Domain.Entities;

public class Role : Auditable
{
    public required string Name { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
