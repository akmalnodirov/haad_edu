namespace HaadEdu.Domain.Entities;

public class UnitOfCourse : BaseEntity
{
    public Attachment Attachment { get; set; }
    public string Description { get; set; }
    public long AttachmentId {  get; set; }
    public long CourseId {  get; set; }
}
