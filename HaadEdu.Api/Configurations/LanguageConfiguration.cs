using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace HaadEdu.Api.Configurations;

public static class LanguageConfiguration
{
    /// <summary>
    /// Configures the application.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    public static void ConfigureLanguage(this IServiceCollection services)
    {
        services.AddLocalization(options => options.ResourcesPath = "AppLanguage");
    }

    /// <summary>
    /// Uses the application configuration.
    /// </summary>
    /// <param name="app">The application.</param>
    public static void UseLanguageConfiguration(this IApplicationBuilder app)
    {
        var supportedCultures = new[]
        {
            new CultureInfo("en"),
            new CultureInfo("uz"),
            new CultureInfo("ru"),
        };

        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("en"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        });

        app.Use(async (context, next) =>
        {
            var langHeader = context.Request.Headers["app-language"].ToString();
            if (string.IsNullOrEmpty(langHeader) || !supportedCultures.Any(c => c.Name == langHeader))
                langHeader = "en";

            var culture = new CultureInfo(langHeader);

            if (Array.Exists(supportedCultures, c => c.Name == culture.Name))
            {
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }
            else
            {
                CultureInfo.CurrentCulture = new CultureInfo("en");
                CultureInfo.CurrentUICulture = new CultureInfo("en");
            }

            await next();
        });

    }
}
