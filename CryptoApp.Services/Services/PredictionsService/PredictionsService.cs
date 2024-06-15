using CryptoApp.DataFetcher.CoinGeckoDataFetcher.CoinGeckoFetcherContracts;
using CryptoApp.Services.Models;
using CryptoApp.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.Services.PredictionsService
{
    public class PredictionsService : IPredictionsService
    {
        private readonly ICoinGeckoFetcher _dataFetcher;

        public PredictionsService(ICoinGeckoFetcher dataFetcher)
        {
            _dataFetcher = dataFetcher;
        }

        public async Task<MarketChartDataViewData> GetMarketChartData(string inputCoin)
        {
            var allCoinGeckoCoins = await _dataFetcher.GetAllCoinsAsync();

            var allCoins = allCoinGeckoCoins?.Select(x => x.ToCoin()).OrderBy(c => c.MarketCapRank).ToList();

            var matchingCoin = allCoins?.FirstOrDefault(c => c.Symbol?.ToLower() == inputCoin.ToLower() || c.Name?.ToLower() == inputCoin.ToLower());

            if (matchingCoin?.Id == null)
            {
                return new MarketChartDataViewData();
            }

            var chartData = await _dataFetcher.GetMarketChartDataAsync(matchingCoin.Id);

            if (chartData == null)
            {
                return new MarketChartDataViewData();
            }

            var chartDataViewModel = new MarketChartDataViewData
            {
                CoinName = matchingCoin.Name,
                Prices = chartData.Prices,
                MarketCaps = chartData.MarketCaps,
                TotalVolumes = chartData.TotalVolumes
            };

            return chartDataViewModel;
        }
    }
}
