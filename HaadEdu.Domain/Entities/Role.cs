namespace HaadEdu.Domain.Entities;

public class Role : BaseEntity
{
    public required string Name { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
