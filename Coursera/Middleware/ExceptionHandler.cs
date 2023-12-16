using System.Text.Json;
using System.Text.Json.Serialization;

namespace Coursera.Middleware;

public class ExceptionHandler(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            Console.WriteLine("im coming baby");
            await _next(context);
            Console.WriteLine("im leaving baby");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var jsonResponse = JsonSerializer.Serialize(ex.Message);
            await context.Response.WriteAsync(jsonResponse);
        }
    }

}
