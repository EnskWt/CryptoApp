using CryptoApp.DataFetcher.Attributes;
using CryptoApp.DataFetcher.CoinGeckoDataFetcher.CoinGeckoModels;

namespace CryptoApp.DataFetcher.CoinGeckoDataFetcher.CoinGeckoFetcherContracts
{
    public interface ICoinGeckoFetcher
    {
        [Endpoint("coins/list")]
        Task<List<CoinGeckoCoin>?> GetAllCoinsAsync();
    }
}
