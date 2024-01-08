namespace HaadEdu.Domain.Entities;

public class UserSubscription
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public IList<long>? CourseId { get; set; }
}
