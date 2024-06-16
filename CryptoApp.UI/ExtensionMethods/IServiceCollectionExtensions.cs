using CryptoApp.DataFetcher.CoinGeckoDataFetcher;
using CryptoApp.DataFetcher.CoinGeckoDataFetcher.CoinGeckoFetcherContracts;
using CryptoApp.Services.Services.CoinSearchService;
using CryptoApp.Services.Services.ConverterService;
using CryptoApp.Services.Services.MarketAnalyticsService;
using CryptoApp.Services.Services.NewsService;
using CryptoApp.Services.Services.PredictionsService;
using CryptoApp.UI.Pages;
using CryptoApp.UI.Pages.CoinSearchPage;
using CryptoApp.UI.Pages.ConverterPage;
using CryptoApp.UI.Pages.MainMenuPage;
using CryptoApp.UI.Pages.MarketAnalyticsPage;
using CryptoApp.UI.Pages.NewsPage;
using CryptoApp.UI.Pages.PredictionsPage;
using CryptoApp.UI.Pages.SettingsPage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.ExtensionMethods
{
    public static class IServiceCollectionExtensions
    {
        public static void Configure(this IServiceCollection services)
        {
            services.AddDataFetchers();
            services.AddServices();
            services.AddPages();
            services.AddApp();
        }

        private static void AddDataFetchers(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            services.AddHttpClient("CoinGeckoClient", client =>
            {
                client.BaseAddress = new Uri(configuration!["CoinGecko:BaseAddress"]!);
            });

            services.AddTransient<ICoinGeckoFetcher, CoinGeckoFetcher>(provider =>
            {
                var httpClient = new HttpClient { BaseAddress = new Uri(configuration!["CoinGecko:BaseAddress"]!) };
                return new CoinGeckoFetcher(httpClient);
            });

        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICoinSearchService, CoinSearchService>();
            services.AddTransient<IConverterService, ConverterService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IMarketAnalyticsService, MarketAnalyticsService>();
            services.AddTransient<IPredictionsService, PredictionsService>();
        }

        private static void AddPages(this IServiceCollection services)
        {
            services.AddTransient<MainMenuPage>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<CoinSearchPage>();
            services.AddTransient<ConverterPage>();
            services.AddTransient<NewsPage>();
            services.AddTransient<MarketAnalyticsPage>();
            services.AddTransient<PredictionsPage>();
        }

        private static void AddApp(this IServiceCollection services)
        {
            services.AddSingleton<App>();
        }
    }
}
