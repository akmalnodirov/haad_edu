namespace HaadEdu.Domain.Entities;

public class Auditable : BaseEntity
{
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedTime { get; set; } = DateTime.UtcNow;
}
