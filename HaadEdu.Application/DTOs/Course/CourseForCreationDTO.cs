

using HaadEdu.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace HaadEdu.Application.DTOs.Course
{
    public class CourseForCreationDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile file { get; set; }
    }

}