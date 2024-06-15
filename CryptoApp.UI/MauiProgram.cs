using CryptoApp.UI.CustomControls;
using CryptoApp.UI.ExtensionMethods;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using OxyPlot.Maui.Skia;
using System.Reflection;
using OxyPlot;
using OxyPlot.Maui;
using OxyPlot.Series;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace CryptoApp.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("CryptoApp.UI.appsettings.json");

            var config = new ConfigurationBuilder()
                        .AddJsonStream(stream!)
                        .Build();

            builder.Configuration.AddConfiguration(config);
            builder.Services.AddSingleton<IConfiguration>(config);

            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .UseOxyPlotSkia()
#if ANDROID
                .ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddHandler<CustomViewCell, Platforms.Android.CustomViewCellHandler>();
                })
#endif
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.Configure();

            builder.Services.AddSingleton<App>();

            // TODO
#if WINDOWS
            SwitchHandler.Mapper.AppendToMapping("Custom", (h, v) =>
            {
                h.PlatformView.OffContent = string.Empty;
                h.PlatformView.OnContent = string.Empty;

                h.PlatformView.MinWidth = 0;
            });
#endif

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var mauiApp = builder.Build();

            var serviceProvider = mauiApp.Services;

            var app = serviceProvider.GetRequiredService<App>();
            return mauiApp;
        }
    }
}
