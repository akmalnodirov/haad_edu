namespace HaadEdu.Domain.Entities;

public class Role : Audituble
{
    public required string Name { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
