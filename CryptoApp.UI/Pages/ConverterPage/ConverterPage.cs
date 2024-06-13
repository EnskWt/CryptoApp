using CryptoApp.Services.ConverterService;
using CryptoApp.UI.Attributes;
using CryptoApp.UI.Pages.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Pages.ConverterPage
{
    [PageTitle("Converter")]
    public partial class ConverterPage : ApplicationPage
    {
        private readonly IConverterService _converterService;

        public ConverterPage(IConverterService converterService) : base()
        {
            _converterService = converterService;
        }

        protected override async Task<Layout> BuildPageLayout()
        {
            var appLayout = await base.BuildPageLayout();

            _inputCoinEntry = await GetInputCoinEntry();
            _inputAmountEntry = await GetAmountInputEntry();

            _outputCoinEntry = await GetOutputCoinEntry();
            _outputAmountEntry = await GetAmountOutputEntry();

            var switchCoinEntriesButton = await GetSwitchCoinEntriesButton();
            var switchAmountEntriesButton = await GetSwitchAmountEntriesButton();

            var coinsLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    _inputCoinEntry,
                    switchCoinEntriesButton,
                    _outputCoinEntry,
                }
            };

            var amountsLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    _inputAmountEntry,
                    switchAmountEntriesButton,
                    _outputAmountEntry,
                }
            };

            var convertButton = await GetConvertButton();

            _mainLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(10),
                Children =
                {
                    coinsLayout,
                    amountsLayout,
                    convertButton
                }
            };

            appLayout.Children.Add(_mainLayout);

            return appLayout;
        }

        private async void OnSwitchCoinEntriesButtonClicked(object? sender, EventArgs e)
        {
            var temp = _inputCoinEntry.Text;
            _inputCoinEntry.Text = _outputCoinEntry.Text;
            _outputCoinEntry.Text = temp;

            await Task.CompletedTask;
        }

        private async void OnSwitchAmountEntriesButtonClicked(object? sender, EventArgs e)
        {
            var temp = _inputAmountEntry.Text;
            _inputAmountEntry.Text = _outputAmountEntry.Text;
            _outputAmountEntry.Text = temp;

            await Task.CompletedTask;
        }

        private async void OnConvertButtonClicked(object? sender, EventArgs e)
        {
            await ShowLoader();
            _mainLayout.IsEnabled = false;

            var inputCoin = _inputCoinEntry.Text;
            var outputCoin = _outputCoinEntry.Text;

            var inputAmount = _inputAmountEntry.Text;

            var convertResult = await _converterService.ConvertCurrency(inputCoin, outputCoin, double.Parse(inputAmount));

            _inputCoinEntry.Text = convertResult.InputCurrencyName;
            _outputCoinEntry.Text = convertResult.OutputCurrencyName;

            _inputAmountEntry.Text = convertResult.InputAmount;
            _outputAmountEntry.Text = convertResult.OutputAmount;

            _mainLayout.IsEnabled = true;
            await HideLoader();
        }
    }
}
