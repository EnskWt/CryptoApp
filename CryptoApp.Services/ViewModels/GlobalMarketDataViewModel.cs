using CryptoApp.DataFetcher.CoinGeckoDataFetcher.Models.CoinGeckoModels;
using CryptoApp.Shared.ExtensionMethods;

namespace CryptoApp.Services.ViewModels
{
    public class GlobalMarketDataViewModel
    {
        public string? ActiveCryptocurrenciesCount { get; set; }
        public string? MarketsCount { get; set; }
        public string? UpcomingIcosCount { get; set; }
        public string? OngoingIcosCount { get; set; }
        public string? EndedIcosCount { get; set; }
        public string? TotalVolume { get; set; }
        public string? MarketCapChangePercentage { get; set; }
    }

    public static class GlobalMarketDataViewModelExtensions
    {
        public static GlobalMarketDataViewModel ToGlobalMarketData(this CoinGeckoGlobalData coinGeckoGlobalData)
        {
            return new GlobalMarketDataViewModel
            {
                ActiveCryptocurrenciesCount = coinGeckoGlobalData.ActiveCryptocurrenciesCount.ToString(),
                MarketsCount = coinGeckoGlobalData.MarketsCount.ToString(),
                UpcomingIcosCount = coinGeckoGlobalData.UpcomingIcosCount.ToString(),
                OngoingIcosCount = coinGeckoGlobalData.OngoingIcosCount.ToString(),
                EndedIcosCount = coinGeckoGlobalData.EndedIcosCount.ToString(),
                TotalVolume = coinGeckoGlobalData.TotalVolume?["usd"].ToMathStringWithSuffix('$'),
                MarketCapChangePercentage = coinGeckoGlobalData.MarketCapChangePercentage.ToStringWithSuffix('%')
            };
        }
    }
}
