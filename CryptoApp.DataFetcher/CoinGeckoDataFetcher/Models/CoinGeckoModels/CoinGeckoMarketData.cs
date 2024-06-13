using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.DataFetcher.CoinGeckoDataFetcher.Models.CoinGeckoModels
{
    public class CoinGeckoMarketData
    {
        [JsonProperty("current_price")]
        public Dictionary<string, double>? CurrentPrice { get; set; }

        [JsonProperty("market_cap")]
        public Dictionary<string, double>? MarketCap { get; set; }

        [JsonProperty("total_volume")]
        public Dictionary<string, double>? TotalVolume { get; set; }

        [JsonProperty("high_24h")]
        public Dictionary<string, double>? High24h { get; set; }

        [JsonProperty("low_24h")]
        public Dictionary<string, double>? Low24h { get; set; }

        [JsonProperty("price_change_24h")]
        public double? PriceChange24h { get; set; }

        [JsonProperty("price_change_percentage_24h")]
        public double? PriceChangePercentage24h { get; set; }
    }
}
