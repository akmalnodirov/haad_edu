namespace Coursera.Models;

public class UserRole
{
    public int Id { get; set; }

    public User User { get; set; }
    public Role Role { get; set; }
}
