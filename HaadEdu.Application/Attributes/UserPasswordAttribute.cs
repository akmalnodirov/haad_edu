using System.ComponentModel.DataAnnotations;

namespace HaadEdu.Application.Attributes
{
    public class UserPasswordAttribute : ValidationAttribute
    {
       
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string password && password.Length >= 8 && password.Any(c => char.IsDigit(c))
                    && password.Any(c => char.IsLetter(c))) ;
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("Sizning parolingiz yaroqli emas");
            }
        }
    }
}
