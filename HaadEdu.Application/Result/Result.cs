using Microsoft.Extensions.Localization;

namespace HaadEdu.Application.Result;

public class Result<T> where T : class
{
    public T? Value { get; set; }
    public Error? Error { get; set; }
    public bool Success { get; set; } = false;
    public Result(T result)
    {
        Value = result;
        Success = true;
    }

    public Result(KeyValuePair<int, string> response, IStringLocalizer<AppLanguage>? localizer = null)
    {
        Error = new Error
        {
            Message = localizer != null ? localizer[response.Value] : response.Value,
            Code = response.Key
        };
    }
}
