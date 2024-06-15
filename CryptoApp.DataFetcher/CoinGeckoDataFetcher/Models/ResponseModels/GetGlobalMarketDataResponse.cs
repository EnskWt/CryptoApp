using CryptoApp.DataFetcher.CoinGeckoDataFetcher.Models.CoinGeckoModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.DataFetcher.CoinGeckoDataFetcher.Models.ResponseModels
{
    public class GetGlobalMarketDataResponse
    {
        [JsonProperty("data")]
        public CoinGeckoGlobalData? Data { get; set; }
    }
}
