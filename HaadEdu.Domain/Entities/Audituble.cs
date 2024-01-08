namespace HaadEdu.Domain.Entities
{
    public class Audituble : BaseEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedTime { get; set; } = DateTime.UtcNow;
    }
}
}
