using CryptoApp.DataFetcher.CoinGeckoDataFetcher.CoinGeckoFetcherContracts;
using CryptoApp.Services.Models;
using CryptoApp.Services.ViewModels;
using CryptoApp.Shared.ExtensionMethods;

namespace CryptoApp.Services.Services.ConverterService
{
    public class ConverterService : IConverterService
    {
        private readonly ICoinGeckoFetcher _dataFetcher;
        public ConverterService(ICoinGeckoFetcher dataFetcher)
        {
            _dataFetcher = dataFetcher;
        }

        public async Task<ConvertResultViewModel> ConvertCurrency(string inputCurrency, string outputCurrency, double inputAmount)
        {
            var allCoinGeckoCoins = await _dataFetcher.GetAllCoinsAsync();

            var allCoins = allCoinGeckoCoins?.Select(x => x.ToCoin()).OrderBy(c => c.MarketCapRank).ToList();

            var inputCoin = allCoins?.FirstOrDefault(c => c.Symbol?.ToLower() == inputCurrency.ToLower() || c.Name?.ToLower() == inputCurrency.ToLower());
            var outputCoin = allCoins?.FirstOrDefault(c => c.Symbol?.ToLower() == outputCurrency.ToLower() || c.Name?.ToLower() == outputCurrency.ToLower());

            if (inputCoin?.Id == null || outputCoin?.Id == null)
            {
                return new ConvertResultViewModel();
            }

            var inputCoinGeckoCoin = await _dataFetcher.GetCoinInfoAsync(inputCoin.Id);
            var outputCoinGeckoCoin = await _dataFetcher.GetCoinInfoAsync(outputCoin.Id);

            var inputCoinInfo = inputCoinGeckoCoin?.ToCoin();
            var outputCoinInfo = outputCoinGeckoCoin?.ToCoin();

            if (inputCoinInfo?.CurrentPrice == null || outputCoinInfo?.CurrentPrice == null)
            {
                return new ConvertResultViewModel();
            }

            var exchangeRate = inputCoinInfo.CurrentPrice / outputCoinInfo.CurrentPrice;

            var outputAmount = inputAmount * exchangeRate ?? 0;

            var convertResult = new ConvertResultViewModel
            {
                InputCurrencyName = inputCoin.Name,
                OutputCurrencyName = outputCoin.Name,
                InputAmount = inputAmount.ToString("0.##"),
                OutputAmount = outputAmount.ToString("0.##")
            };

            return convertResult;
        }
    }
}
