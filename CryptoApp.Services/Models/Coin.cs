using CryptoApp.DataFetcher.CoinGeckoDataFetcher.CoinGeckoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.Models
{
    public class Coin
    {
        public string? Id { get; set; }

        public string? Symbol { get; set; }

        public string? Name { get; set; }
    }

    public static class CoinExtensions
    {
        public static Coin ToCoin(this CoinGeckoCoin coin)
        {
            return new Coin
            {
                Id = coin.Id,
                Symbol = coin.Symbol,
                Name = coin.Name
            };
        }
    }
}
