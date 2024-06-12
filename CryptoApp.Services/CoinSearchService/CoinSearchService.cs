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

        public async Task<List<ShortCoinViewModel>?> GetCoinsForSearchCoinsPicker()
        {
            var coinGeckoCoins = await _dataFetcher.GetAllCoinsAsync();

            var coins = coinGeckoCoins?.Take(10).Select(c => c.ToCoin().ToShortCoin()).ToList();

            return coins;
        }
    }
}
