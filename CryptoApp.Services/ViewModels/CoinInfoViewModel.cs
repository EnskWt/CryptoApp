using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoApp.Services.Models;
using CryptoApp.Shared.ExtensionMethods;

namespace CryptoApp.Services.ViewModels
{
    public class CoinInfoViewModel
    {
        public string? Id { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? CurrentPrice { get; set; }
        public string? MarketCap { get; set; }
        public string? TotalVolume { get; set; }
        public string? High24h { get; set; }
        public string? Low24h { get; set; }
        public string? PriceChange24h { get; set; }
        public string? PriceChangePercentage24h { get; set; }
        public string? MarketCapRank { get; set; }
    }

    public static class CoinInfoViewModelExtensions
    {
        public static CoinInfoViewModel ToCoinInfo(this Coin coin)
        {
            return new CoinInfoViewModel
            {
                Id = coin.Id,
                Symbol = coin.Symbol,
                Name = coin.Name,
                Image = coin.Image,
                CurrentPrice = coin.CurrentPrice?.ToMathStringWithSuffix('$'),
                MarketCap = coin.MarketCap?.ToMathStringWithSuffix('$'),
                TotalVolume = coin.TotalVolume?.ToMathStringWithSuffix('$'),
                High24h = coin.High24h?.ToMathStringWithSuffix('$'),
                Low24h = coin.Low24h?.ToMathStringWithSuffix('$'),
                PriceChange24h = coin.PriceChange24h?.ToMathStringWithSuffix('$'),
                PriceChangePercentage24h = coin.PriceChangePercentage24h?.ToMathStringWithSuffix('%'),
                MarketCapRank = coin.MarketCapRank?.ToStringWithSuffix('#')
            };
        }
    }
}
