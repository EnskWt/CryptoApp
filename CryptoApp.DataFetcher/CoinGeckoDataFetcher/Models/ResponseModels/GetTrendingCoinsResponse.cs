using CryptoApp.DataFetcher.CoinGeckoDataFetcher.Models.CoinGeckoModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.DataFetcher.CoinGeckoDataFetcher.Models.ResponseModels
{
    public class GetTrendingCoinsResponse
    {
        [JsonProperty("coins")]
        public List<CoinGeckoTrendingCoin>? TrendingCoins { get; set; }
    }

    public class CoinGeckoTrendingCoin
    {
        [JsonProperty("item")]
        public CoinGeckoCoin CoinGeckoCoin { get; set; } = null!;
    }
}
