using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

namespace CryptoApp.UI
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

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

            return builder.Build();
        }
    }
}
