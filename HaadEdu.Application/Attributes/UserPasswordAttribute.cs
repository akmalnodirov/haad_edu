using System.ComponentModel.DataAnnotations;

namespace HaadEdu.Application.Attributes;

public class UserPasswordAttribute : ValidationAttribute
{

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string password && password.Length >= 8 && password.Any(char.IsDigit)
            && password.Any(char.IsLetter))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Sizning parolingiz yaroqli emas");
    }

}
