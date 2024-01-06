namespace HaadEdu.Domain.Entities;

public class Course : Audituble
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Attachment Attachment { get; set; }
    public long AttachmetId { get; set; }
    public ICollection<UnitOfCourse> Courses { get; set; }
}
