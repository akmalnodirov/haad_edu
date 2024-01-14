namespace HaadEdu.Domain.Entities;

public class RolePermission : Auditable
{
    public long RoleId { get; set; }
    public Role? Role { get; set; }
    public Permissions Permission { get; set; }
}
