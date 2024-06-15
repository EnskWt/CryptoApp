using CryptoApp.Services.Services.CoinSearchService;
using CryptoApp.Services.ViewModels;
using CryptoApp.UI.Attributes;
using CryptoApp.UI.CustomControls;
using CryptoApp.UI.LanguageFramework;
using CryptoApp.UI.Pages.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApp.UI.Pages.CoinSearchPage
{

    [PageTitle("Coin Search")]
    public partial class CoinSearchPage : ApplicationPage
    {
        private readonly ICoinSearchService _coinSearchService;

        public CoinSearchPage(ICoinSearchService coinSearchService) : base()
        {
            _coinSearchService = coinSearchService;
        }

        protected override async Task<Layout> BuildPageLayout()
        {
            var appLayout = await base.BuildPageLayout();

            var searchSectionLayout = await BuildSearchSection();

            var coinInfoLayout = await BuildCoinInfoSection();

            appLayout.Children.Add(searchSectionLayout);
            appLayout.Children.Add(coinInfoLayout);

            return appLayout;
        }

        private async void OnSearchButtonClicked(object? sender, EventArgs e)
        {
            await DisableSearchPicker();

            var searchQuery = _entry.Text;
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                await UpdateSuggestions(_initialCoins);
            }
            else
            {

                var coins = await _coinSearchService.GetCoinsForSearchCoinsPicker(searchQuery);
                await UpdateSuggestions(coins);
            }

            await EnableSearchPicker();
        }

        private async void OnSearchResultListViewItemSelected(object? sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selectedCoin = e.SelectedItem as ShortCoinViewModel;
                if (selectedCoin != null)
                {
                    await FillCoinInfoLayout(selectedCoin.Id);
                }
            }
        }

        private async void HighlightSelectedItem(object? sender, EventArgs e)
        {
            var cell = sender as CustomViewCell;
            if (cell != null)
            {
                cell.SelectedBackgroundColor = Colors.LightGray;
                Dispatcher.StartTimer(TimeSpan.FromMilliseconds(1), () =>
                {
                    cell.SelectedBackgroundColor = Colors.Transparent;
                    return false;
                });
            }

            await Task.CompletedTask;
        }

        private async Task LoadInitialCoins()
        {
            _initialCoins = await _coinSearchService.GetInitialCoinsForSearchCoinsPicker();
            await UpdateSuggestions(_initialCoins);
        }

        private async Task UpdateSuggestions(List<ShortCoinViewModel> coins)
        {
            _suggestions.Clear();

            foreach (var coin in coins)
            {
                _suggestions.Add(coin);
            }
            _searchResultsListView.IsVisible = _suggestions.Count > 0;
            _noDataLabel.IsVisible = _suggestions.Count <= 0;

            await Task.CompletedTask;
        }

        private async Task EnableSearchPicker()
        {
            await HideSearchPickerLoader();

            _searchButton.IsEnabled = true;
            _searchResultsListView.IsEnabled = true;
        }

        private async Task DisableSearchPicker()
        {
            _searchButton.IsEnabled = false;

            _searchResultsListView.IsEnabled = false;
            _searchResultsListView.IsVisible = false;

            _noDataLabel.IsVisible = false;

            await ShowSearchPickerLoader();
        }

        private async Task ShowSearchPickerLoader()
        {
            _searchPickerLoader.IsVisible = true;
            _searchPickerLoader.IsRunning = true;
            await Task.CompletedTask;
        }

        private async Task HideSearchPickerLoader()
        {
            _searchPickerLoader.IsVisible = false;
            _searchPickerLoader.IsRunning = false;
            await Task.CompletedTask;
        }

        private async Task ShowCoinInfoLoader()
        {
            _coinInfoSectionLoader.IsVisible = true;
            _coinInfoSectionLoader.IsRunning = true;

            _searchResultsListView.IsEnabled = false;

            await Task.CompletedTask;
        }

        private async Task HideCoinInfoLoader()
        {
            _searchResultsListView.IsEnabled = true;

            _coinInfoSectionLoader.IsVisible = false;
            _coinInfoSectionLoader.IsRunning = false;
            await Task.CompletedTask;
        }
    }
}
