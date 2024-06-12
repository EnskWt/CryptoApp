using CryptoApp.DataFetcher.CoinGeckoDataFetcher;
using CryptoApp.DataFetcher.CoinGeckoDataFetcher.CoinGeckoFetcherContracts;
using CryptoApp.Services.CoinSearchService;
using CryptoApp.UI.Pages.CoinSearchPage;
using CryptoApp.UI.Pages.MainMenu;
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
        }

        private static void AddPages(this IServiceCollection services)
        {
            services.AddTransient<MainMenuPage>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<CoinSearchPage>();
        }
    }
}
