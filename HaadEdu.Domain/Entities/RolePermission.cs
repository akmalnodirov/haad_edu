namespace HaadEdu.Domain.Entities;

public class RolePermission : BaseEntity
{
    public long RoleId { get; set; }
    public Role? Role { get; set; }
    public Permissions PermissionsCode { get; set; }
}
