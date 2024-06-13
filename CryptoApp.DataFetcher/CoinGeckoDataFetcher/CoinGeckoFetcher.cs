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

        [Endpoint("simple/price?ids={inputCoinId}&vs_currencies={outputCoinId}")]
        public async Task<double> GetExchangeRateAsync(string inputCoinId, string outputCoinId)
        {
            var endpoint = GetEndpointUrl(new { inputCoinId, outputCoinId });

            var response = await _httpClient.GetStringAsync(endpoint);
            var responseObject = JsonConvert.DeserializeObject<GetExchangeRateResponse>(response);

            var rates = responseObject?.Rates;

            if (rates != null && rates.ContainsKey(inputCoinId) && rates[inputCoinId].ContainsKey(outputCoinId))
            {
                return rates[inputCoinId][outputCoinId];
            }

            return 0;
        }
    }
}
