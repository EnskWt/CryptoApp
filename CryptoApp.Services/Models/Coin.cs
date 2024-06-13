using CryptoApp.DataFetcher.CoinGeckoDataFetcher.Models.CoinGeckoModels;
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
        public string? Image { get; set; }
        public double? CurrentPrice { get; set; }
        public double? MarketCap { get; set; }
        public double? TotalVolume { get; set; }
        public double? High24h { get; set; }
        public double? Low24h { get; set; }
        public double? PriceChange24h { get; set; }
        public double? PriceChangePercentage24h { get; set; }
        public int? MarketCapRank { get; set; }
    }

    public static class CoinExtensions
    {
        public static Coin ToCoin(this CoinGeckoCoin coin)
        {
            return new Coin
            {
                Id = coin.Id,
                Symbol = coin.Symbol,
                Name = coin.Name,
                Image = coin.Image?.Large,
                CurrentPrice = coin.MarketData?.CurrentPrice?["usd"],
                MarketCap = coin.MarketData?.MarketCap?["usd"],
                TotalVolume = coin.MarketData?.TotalVolume?["usd"],
                High24h = coin.MarketData?.High24h?["usd"],
                Low24h = coin.MarketData?.Low24h?["usd"],
                PriceChange24h = coin.MarketData?.PriceChange24h,
                PriceChangePercentage24h = coin.MarketData?.PriceChangePercentage24h,
                MarketCapRank = coin.MarketCapRank
            };
        }
    }
}
