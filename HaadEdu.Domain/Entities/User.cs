namespace HaadEdu.Domain.Entities;

public class User : Auditable
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public long? RoleId { get; set; }
    public Role? Role { get; set; }
}
