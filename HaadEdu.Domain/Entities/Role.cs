namespace HaadEdu.Domain.Entities;

public class Role : BaseEntity
{
    public required string Name { get; set; }
    public ICollection<Permissions>? Permissions { get; set; } = new List<Permissions>();
}
