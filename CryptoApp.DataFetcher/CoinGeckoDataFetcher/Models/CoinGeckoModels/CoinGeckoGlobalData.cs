using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.DataFetcher.CoinGeckoDataFetcher.Models.CoinGeckoModels
{
    public class CoinGeckoGlobalData
    {
        [JsonProperty("active_cryptocurrencies")]
        public int ActiveCryptocurrenciesCount { get; set; }

        [JsonProperty("markets")]
        public int MarketsCount { get; set; }

        [JsonProperty("upcoming_icos")]
        public int UpcomingIcosCount { get; set; }

        [JsonProperty("ongoing_icos")]
        public int OngoingIcosCount { get; set; }

        [JsonProperty("ended_icos")]
        public int EndedIcosCount { get; set; }

        [JsonProperty("total_volume")]
        public Dictionary<string, double>? TotalVolume { get; set; }

        [JsonProperty("market_cap_change_percentage_24h_usd")]
        public double MarketCapChangePercentage { get; set; }
    }
}
