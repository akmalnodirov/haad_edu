namespace HaadEdu.Domain.Entities;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedTime { get; set; } = DateTime.UtcNow;
}
