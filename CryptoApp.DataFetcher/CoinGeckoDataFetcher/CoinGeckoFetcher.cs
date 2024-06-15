using CryptoApp.DataFetcher.Attributes;
using CryptoApp.DataFetcher.CoinGeckoDataFetcher.CoinGeckoFetcherContracts;
using CryptoApp.DataFetcher.CoinGeckoDataFetcher.Models.CoinGeckoModels;
using CryptoApp.DataFetcher.CoinGeckoDataFetcher.Models.ResponseModels;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace CryptoApp.DataFetcher.CoinGeckoDataFetcher
{
    public class CoinGeckoFetcher : BaseDataFetcher, ICoinGeckoFetcher
    {
        private readonly HttpClient _httpClient;

        public CoinGeckoFetcher(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Endpoint("coins/list")]
        public async Task<List<CoinGeckoCoin>?> GetAllCoinsAsync()
        {
            var endpoint = GetEndpointUrl();

            var response = await _httpClient.GetStringAsync(endpoint);
            var allCoins = JsonConvert.DeserializeObject<List<CoinGeckoCoin>>(response);

            return allCoins;
        }

        [Endpoint("search/trending")]
        public async Task<List<CoinGeckoCoin>?> GetTrendingCoinsAsync()
        {
            var endpoint = GetEndpointUrl();

            var response = await _httpClient.GetStringAsync(endpoint);
            var trendingResponse = JsonConvert.DeserializeObject<GetTrendingCoinsResponse>(response);

            var coinGeckoCoins = trendingResponse?.TrendingCoins?.Select(c => c.CoinGeckoCoin).ToList();
            return coinGeckoCoins;
        }

        [Endpoint("search?query={query}")]
        public async Task<List<CoinGeckoCoin>?> GetFilteredCoinsAsync(string query)
        {
            var endpoint = GetEndpointUrl(new { query });

            var response = await _httpClient.GetStringAsync(endpoint);
            var filteredCoinGeckoCoins = JsonConvert.DeserializeObject<GetFilteredCoinsResponse>(response);

            var coinGeckoCoins = filteredCoinGeckoCoins?.CoinGeckoCoins?.ToList();
            return coinGeckoCoins;
        }

        [Endpoint("coins/{coinId}")]
        public async Task<CoinGeckoCoin?> GetCoinInfoAsync(string coinId)
        {
            var endpoint = GetEndpointUrl(new { coinId });

            var response = await _httpClient.GetStringAsync(endpoint);
            var responseObject = JsonConvert.DeserializeObject<CoinGeckoCoin>(response);

            var coinGeckoCoin = responseObject;

            return coinGeckoCoin;
        }

        [Endpoint("global")]
        public async Task<CoinGeckoGlobalData?> GetGlobalMarketDataAsync()
        {
            var endpoint = GetEndpointUrl();

            var response = await _httpClient.GetStringAsync(endpoint);
            var responseObject = JsonConvert.DeserializeObject<GetGlobalMarketDataResponse>(response);

            var globalData = responseObject?.Data;

            return globalData;
        }

        [Endpoint("coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1")]
        public async Task<List<CoinGeckoMarketCoin>?> GetTopCoinsAsync()
        {
            var endpoint = GetEndpointUrl();

            var response = await _httpClient.GetStringAsync(endpoint);
            var topCoins = JsonConvert.DeserializeObject<List<CoinGeckoMarketCoin>>(response);

            return topCoins;
        }

        [Endpoint("coins/markets?vs_currency=usd&order=price_change_percentage_7d_desc&per_page=10&page=1")]
        public async Task<List<CoinGeckoMarketCoin>?> GetRecommendedCoinsAsync()
        {
            var endpoint = GetEndpointUrl();

            var response = await _httpClient.GetStringAsync(endpoint);
            var recommendedCoins = JsonConvert.DeserializeObject<List<CoinGeckoMarketCoin>>(response);

            return recommendedCoins;
        }

        [Endpoint("coins/{coinId}/market_chart?vs_currency=usd&days=7")]
        public async Task<CoinGeckoMarketChartData?> GetMarketChartDataAsync(string coinId)
        {
            var endpoint = GetEndpointUrl(new { coinId });

            var response = await _httpClient.GetStringAsync(endpoint);
            var marketChartData = JsonConvert.DeserializeObject<CoinGeckoMarketChartData>(response);

            return marketChartData;
        }
    }
}
