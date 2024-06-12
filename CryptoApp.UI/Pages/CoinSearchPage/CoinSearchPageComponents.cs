using CryptoApp.UI.Pages.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Pages.CoinSearchPage
{
    public partial class CoinSearchPage : ApplicationPage
    {
        private async Task<Picker> CreateCoinPicker()
        {
            var coins = await _coinSearchService.GetCoinsForSearchCoinsPicker();
            var coinPicker = new Picker
            {
                Title = "Select a Coin",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            coinPicker.ItemsSource = coins;
            coinPicker.ItemDisplayBinding = new Binding("Name");

            return coinPicker;
        }
    }
}
