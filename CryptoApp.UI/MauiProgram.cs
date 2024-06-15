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

            var config = GetConfiguration();

            builder.Configuration.AddConfiguration(config);
            builder.Services.AddSingleton(config);

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

            #if DEBUG
            builder.Logging.AddDebug();
            #endif

            var mauiApp = builder.Build();

            var serviceProvider = mauiApp.Services;

            var app = serviceProvider.GetRequiredService<App>();
            return mauiApp;
        }

        private static IConfiguration GetConfiguration()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("CryptoApp.UI.appsettings.json");

            var config = new ConfigurationBuilder()
                        .AddJsonStream(stream!)
                        .Build();

            return config;
        }
    }
}
