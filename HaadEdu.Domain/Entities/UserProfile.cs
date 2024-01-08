namespace HaadEdu.Domain.Entities;

public class UserProfile : BaseEntity
{
    public long UserId { get; set; }
    public string Username { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
}
