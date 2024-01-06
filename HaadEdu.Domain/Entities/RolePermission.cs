namespace HaadEdu.Domain.Entities;

public class RolePermission : Audituble
{
    public long RoleId { get; set; }
    public Role? Role { get; set; }
    public Permissions Permission { get; set; }
}
