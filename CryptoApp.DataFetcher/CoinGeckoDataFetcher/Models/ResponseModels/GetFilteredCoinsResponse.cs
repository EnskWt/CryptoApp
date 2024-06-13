using CryptoApp.DataFetcher.CoinGeckoDataFetcher.Models.CoinGeckoModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoApp.DataFetcher.CoinGeckoDataFetcher.Models.ResponseModels
{
    public class GetFilteredCoinsResponse
    {
        [JsonProperty("coins")]
        public List<CoinGeckoCoin>? CoinGeckoCoins { get; set; }
    }
}
