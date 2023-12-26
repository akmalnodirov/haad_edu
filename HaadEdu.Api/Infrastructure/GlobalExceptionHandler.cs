using HaadEdu.Application;
using HaadEdu.Application.Result;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Localization;

namespace HaadEdu.Api.Infrastructure;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IStringLocalizer<AppLanguage> localizer) : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger = logger;
    private IStringLocalizer<AppLanguage> _localizer = localizer;

    public async ValueTask<bool> TryHandleAsync(
    HttpContext httpContext,
    Exception exception,
    CancellationToken cancellationToken)
    {
        _logger.LogError(
            exception, "Exception occurred: {Message}", exception.Message);

        var response = new Result<object>(new KeyValuePair<int, string>(
              ErrorMessages.Internal.Key, ErrorMessages.Internal.Value),
              _localizer);

        httpContext.Response.StatusCode = response.Error.Code;

        await httpContext.Response
            .WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}
