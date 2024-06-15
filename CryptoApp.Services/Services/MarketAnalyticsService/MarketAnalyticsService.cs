using CryptoApp.DataFetcher.CoinGeckoDataFetcher.CoinGeckoFetcherContracts;
using CryptoApp.Services.Models;
using CryptoApp.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.Services.MarketAnalyticsService
{
    public class MarketAnalyticsService : IMarketAnalyticsService
    {
        private readonly ICoinGeckoFetcher _dataFetcher;

        public MarketAnalyticsService(ICoinGeckoFetcher dataFetcher)
        {
            _dataFetcher = dataFetcher;
        }

        public async Task<MarketDataViewModel> GetGlobalMarketData()
        {
            var globalMarketData = await _dataFetcher.GetGlobalMarketDataAsync();

            var topCoins = await _dataFetcher.GetTopCoinsAsync();

            var recommendedCoins = await _dataFetcher.GetRecommendedCoinsAsync();

            return new MarketDataViewModel
            {
                GlobalMarketData = globalMarketData?.ToGlobalMarketData(),
                TopCoins = topCoins?.Select(coin => coin.ToCoin().ToShortCoin()).ToList(),
                RecommendedCoins = recommendedCoins?.Select(coin => coin.ToCoin().ToShortCoin()).ToList()
            };
        }
    }
}
