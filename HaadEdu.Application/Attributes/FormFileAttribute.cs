using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HaadEdu.Application.Attributes;

public class FormFileAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value is IFormFile file)
        {
            string[] extansions = new string[] { ".png", ".jpg", ".gif", ".pptx", ".ppt", ".doc", ".docx" };
            var extansion = Path.GetExtension(file.FileName);
            if(!extansions.Contains(extansion.ToLower())) 
            {
                return new ValidationResult("This file extension is not allowed!");
            }
        }
            return ValidationResult.Success;
    }
}
