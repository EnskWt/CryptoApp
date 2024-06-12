using CryptoApp.DataFetcher.Attributes;
using CryptoApp.DataFetcher.CoinGeckoDataFetcher.CoinGeckoFetcherContracts;
using CryptoApp.DataFetcher.CoinGeckoDataFetcher.CoinGeckoModels;
using Newtonsoft.Json;

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
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var coinGeckoCoins = JsonConvert.DeserializeObject<List<CoinGeckoCoin>>(json);

            return coinGeckoCoins;
        }
    }
}
