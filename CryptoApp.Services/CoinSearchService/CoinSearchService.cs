using CryptoApp.DataFetcher.CoinGeckoDataFetcher.CoinGeckoFetcherContracts;
using CryptoApp.Services.Models;
using CryptoApp.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.CoinSearchService
{
    public class CoinSearchService : ICoinSearchService
    {
        private readonly ICoinGeckoFetcher _dataFetcher;

        public CoinSearchService(ICoinGeckoFetcher dataFetcher)
        {
            _dataFetcher = dataFetcher;
        }

        public async Task<List<ShortCoinViewModel>> GetInitialCoinsForSearchCoinsPicker()
        {
            var coinGeckoCoins = await _dataFetcher.GetTrendingCoinsAsync();

            if (coinGeckoCoins == null)
            {
                return new List<ShortCoinViewModel>();
            }

            var coins = coinGeckoCoins.Take(10).Select(c => c.ToCoin().ToShortCoin()).ToList();

            return coins;
        }

        public async Task<List<ShortCoinViewModel>> GetCoinsForSearchCoinsPicker(string searchQuery)
        {
            var coinGeckoCoins = await _dataFetcher.GetFilteredCoinsAsync(searchQuery);

            if (coinGeckoCoins == null)
            {
                return new List<ShortCoinViewModel>();
            }

            var coins = coinGeckoCoins.Take(10).Select(c => c.ToCoin().ToShortCoin()).ToList();

            return coins;
        }

        public async Task<CoinInfoViewModel> GetCoinInfo(string coinId)
        {
            var coinGeckoCoin = await _dataFetcher.GetCoinInfoAsync(coinId);

            if (coinGeckoCoin == null)
            {
                return new CoinInfoViewModel();
            }

            var coin = coinGeckoCoin.ToCoin().ToCoinInfo();

            return coin;
        }
    }
}
