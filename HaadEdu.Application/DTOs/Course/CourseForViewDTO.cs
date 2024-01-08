using Microsoft.AspNetCore.Http;

namespace HaadEdu.Application.DTOs.Course;

public class CourseForViewDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IFormFile file { get; set; }
}
