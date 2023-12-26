using Microsoft.AspNetCore.Mvc;

namespace HaadEdu.Api.Infrastructure;

public class ModelValidationError(object? value) : ObjectResult(value)
{
}
