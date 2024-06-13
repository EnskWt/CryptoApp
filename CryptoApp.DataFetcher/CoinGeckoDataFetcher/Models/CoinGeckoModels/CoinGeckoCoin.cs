using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.DataFetcher.CoinGeckoDataFetcher.Models.CoinGeckoModels
{
    public class CoinGeckoCoin
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("symbol")]
        public string? Symbol { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("image")]
        public CoinGeckoCoinImage? Image { get; set; }

        [JsonProperty("market_data")]
        public CoinGeckoMarketData? MarketData { get; set; }

        [JsonProperty("market_cap_rank")]
        public int? MarketCapRank { get; set; }
    }
}
