using CryptoApp.DataFetcher.Attributes;
using CryptoApp.DataFetcher.CoinGeckoDataFetcher.Models.CoinGeckoModels;

namespace CryptoApp.DataFetcher.CoinGeckoDataFetcher.CoinGeckoFetcherContracts
{
    public interface ICoinGeckoFetcher
    {
        Task<List<CoinGeckoCoin>?> GetAllCoinsAsync();

        Task<List<CoinGeckoCoin>?> GetTrendingCoinsAsync();

        Task<List<CoinGeckoCoin>?> GetFilteredCoinsAsync(string query);

        Task<CoinGeckoCoin?> GetCoinInfoAsync(string coidId);

        Task<CoinGeckoGlobalData?> GetGlobalMarketDataAsync();

        Task<List<CoinGeckoMarketCoin>?> GetTopCoinsAsync();

        Task<List<CoinGeckoMarketCoin>?> GetRecommendedCoinsAsync();

        Task<CoinGeckoMarketChartData?> GetMarketChartDataAsync(string coinId);
    }
}
