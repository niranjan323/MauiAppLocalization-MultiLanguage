using MauiAppLocalization.Data;
using Microsoft.Extensions.Logging;
using System.Globalization;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
namespace MauiAppLocalization
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();
            // Configure localization services
            builder.Services.AddLocalization(options => options.ResourcesPath = "LanguageResources");

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-GB"),
                    new CultureInfo("ur")
                };

                options.DefaultRequestCulture = new RequestCulture("en-GB");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            return builder.Build();
        }
    }
}
