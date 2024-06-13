using CryptoApp.UI.LanguageFramework;
using CryptoApp.UI.Pages.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Pages.ConverterPage
{
    public partial class ConverterPage : ApplicationPage
    {
        private Entry _inputAmountEntry = null!;
        private Entry _outputAmountEntry = null!;

        private Entry _inputCoinEntry = null!;
        private Entry _outputCoinEntry = null!;

        private StackLayout _mainLayout = null!;

        private async Task<Entry> GetAmountInputEntry()
        {
            var entry = new Entry
            {
                Placeholder = await LanguageManager.GetLabelText(LabelType.InputAmountLabel),
                Keyboard = Keyboard.Numeric,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 125,
                HeightRequest = 50,
                Margin = new Thickness(5)
            };

            return await Task.FromResult(entry);
        }

        private async Task<Entry> GetAmountOutputEntry()
        {
            var entry = new Entry
            {
                Placeholder = await LanguageManager.GetLabelText(LabelType.OutputAmountLabel),
                Keyboard = Keyboard.Numeric,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 125,
                HeightRequest = 50,
                Margin = new Thickness(5),
                IsReadOnly = true
            };

            return await Task.FromResult(entry);
        }

        private async Task<Entry> GetInputCoinEntry()
        {
            var entry = new Entry
            {
                Placeholder = await LanguageManager.GetLabelText(LabelType.InputCurrencyLabel),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 125,
                HeightRequest = 50,
                Margin = new Thickness(5)
            };

            return await Task.FromResult(entry);
        }

        private async Task<Entry> GetOutputCoinEntry()
        {
            var entry = new Entry
            {
                Placeholder = await LanguageManager.GetLabelText(LabelType.OutputCurrencyLabel),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 125,
                HeightRequest = 50,
                Margin = new Thickness(5),
            };

            return await Task.FromResult(entry);
        }

        private async Task<Button> GetConvertButton()
        {
            var button = new Button
            {
                Text = await LanguageManager.GetLabelText(LabelType.ConvertButtonLabel),
                CornerRadius = 10,
                BackgroundColor = Color.FromRgb(211, 211, 211),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 150,
                HeightRequest = 50,
                Margin = new Thickness(10)
            };

            button.Clicked += OnConvertButtonClicked;

            return await Task.FromResult(button);
        }

        private async Task<ImageButton> GetSwitchCoinEntriesButton()
        {
            var button = await GetSwitchButton();

            button.Clicked += OnSwitchCoinEntriesButtonClicked;

            return await Task.FromResult(button);
        }

        private async Task<ImageButton> GetSwitchAmountEntriesButton()
        {
            var button = await GetSwitchButton();

            button.Clicked += OnSwitchAmountEntriesButtonClicked;

            return await Task.FromResult(button);
        }

        private async Task<ImageButton> GetSwitchButton()
        {
            var imageButton = new ImageButton
            {
                Source = "swap.png",
                CornerRadius = 10,
                BackgroundColor = Color.FromRgb(211, 211, 211),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 50,
                HeightRequest = 50,
                Margin = new Thickness(5)
            };

            return await Task.FromResult(imageButton);
        }
    }
}
