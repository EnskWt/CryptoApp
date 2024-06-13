using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.DataFetcher.CoinGeckoDataFetcher.Models.ResponseModels
{
    public class GetExchangeRateResponse
    {
        public Dictionary<string, Dictionary<string, double>>? Rates { get; set; }
    }
}
