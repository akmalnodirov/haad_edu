namespace HaadEdu.Domain.Entities;

public class UserSubscription : BaseEntity
{
    public long UserId { get; set; }
    public IList<long>? CourseId { get; set; }
}
