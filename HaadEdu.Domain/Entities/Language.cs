namespace HaadEdu.Domain.Entities;

public class Language : BaseEntity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public string? Flag { get; set; }
}
