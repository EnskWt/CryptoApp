using CryptoApp.Services.ViewModels;
using CryptoApp.UI.CustomControls;
using CryptoApp.UI.LanguageFramework;
using CryptoApp.UI.Pages.BasePage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Pages.CoinSearchPage
{
    public partial class CoinSearchPage : ApplicationPage
    {
        private Entry _entry = null!;
        private ListView _searchResultsListView = null!;
        private ObservableCollection<ShortCoinViewModel> _suggestions = null!;
        private List<ShortCoinViewModel> _initialCoins = null!;
        private Label _noDataLabel = null!;
        private Button _searchButton = null!;
        private ActivityIndicator _searchPickerLoader = null!;

        private StackLayout _coinInfoLayout = null!;
        private ActivityIndicator _coinInfoSectionLoader = null!;

        private async Task<Layout> BuildSearchSection()
        {
            var searchSectionLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Margin = new Thickness(10),
            };

            var searchCoinLabel = await GetMediumLabel(LabelType.SearchCoinLabel);

            var coinPicker = await CreateSearchableCoinPicker();

            searchSectionLayout.Children.Add(searchCoinLabel);
            searchSectionLayout.Children.Add(coinPicker);

            return searchSectionLayout;
        }

        private async Task<Layout> BuildCoinInfoSection()
        {
            var coinInfoSectionLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Margin = new Thickness(10),
            };

            _coinInfoSectionLoader = await GetMiniLoader();

            _coinInfoLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Margin = new Thickness(10),
                IsVisible = false
            };

            coinInfoSectionLayout.Children.Add(_coinInfoSectionLoader);
            coinInfoSectionLayout.Children.Add(_coinInfoLayout);

            return coinInfoSectionLayout;
        }

        public async Task FillCoinInfoLayout(string? coinId)
        {
            if (string.IsNullOrWhiteSpace(coinId))
            {
                return;
            }

            await ShowCoinInfoLoader();

            _coinInfoLayout.Children.Clear();

            var clearButton = await GetClearButton();

            var coinInfo = await _coinSearchService.GetCoinInfo(coinId);

            var symbol = await GetCoinInfoLabel(LabelType.CoinSymbolLabel, coinInfo.Symbol);
            var name = await GetCoinInfoLabel(LabelType.CoinNameLabel, coinInfo.Name);
            var image = await GetCoinImage(coinInfo.Image);
            var currentPrice = await GetCoinInfoLabel(LabelType.CoinPriceLabel, coinInfo.CurrentPrice);
            var marketCap = await GetCoinInfoLabel(LabelType.CoinMarketCapLabel, coinInfo.MarketCap);
            var totalVolume = await GetCoinInfoLabel(LabelType.CoinTotalVolumeLabel, coinInfo.TotalVolume);
            var highPrice24h = await GetCoinInfoLabel(LabelType.CoinHigh24hLabel, coinInfo.High24h);
            var lowPrice24h = await GetCoinInfoLabel(LabelType.CoinLow24hLabel, coinInfo.Low24h);
            var priceChange24h = await GetCoinInfoLabel(LabelType.CoinPriceChange24hLabel, coinInfo.PriceChange24h);
            var priceChangePercentage24h = await GetCoinInfoLabel(LabelType.CoinPriceChangePercentage24hLabel, coinInfo.PriceChangePercentage24h);
            var marketCapRank = await GetCoinInfoLabel(LabelType.CoinMarketCapRankLabel, coinInfo.MarketCapRank);

            _coinInfoLayout.Children.Add(clearButton);

            _coinInfoLayout.Children.Add(image);
            _coinInfoLayout.Children.Add(symbol);
            _coinInfoLayout.Children.Add(name);
            _coinInfoLayout.Children.Add(currentPrice);
            _coinInfoLayout.Children.Add(marketCap);
            _coinInfoLayout.Children.Add(totalVolume);
            _coinInfoLayout.Children.Add(highPrice24h);
            _coinInfoLayout.Children.Add(lowPrice24h);
            _coinInfoLayout.Children.Add(priceChange24h);
            _coinInfoLayout.Children.Add(priceChangePercentage24h);
            _coinInfoLayout.Children.Add(marketCapRank);

            _coinInfoLayout.IsVisible = true;

            await HideCoinInfoLoader();
        }

        private async Task ClearCoinInfoLayout()
        {
            await ShowCoinInfoLoader();

            _coinInfoLayout.Children.Clear();
            _coinInfoLayout.IsVisible = false;

            await HideCoinInfoLoader();
        }

        private async Task<Button> GetClearButton()
        {
            var clearButton = new Button
            {
                Text = await LanguageManager.GetLabelText(LabelType.ClearButtonLabel),
                FontSize = 14,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Colors.Transparent,
                TextColor = Colors.Black,
                IsVisible = Navigation.NavigationStack.Count > 1
            };

            clearButton.Clicked += async (sender, e) => await ClearCoinInfoLayout();

            return await Task.FromResult(clearButton);
        }

        private async Task<StackLayout> CreateSearchableCoinPicker()
        {
            _entry = await GetSearchInputEntry();

            _searchButton = await GetSearchButton();

            _suggestions = new ObservableCollection<ShortCoinViewModel>();
            _searchResultsListView = await GetSearchResultsListView();

            _noDataLabel = await GetLargeLabel(LabelType.NoDataLabel);

            _searchPickerLoader = await GetMiniLoader();

            var searchablePickerLayout = new StackLayout
            {
                Children =
                {
                    _entry,
                    _searchButton,
                    _searchPickerLoader,
                    _searchResultsListView,
                    _noDataLabel,
                }
            };

            await LoadInitialCoins();

            return searchablePickerLayout;
        }

        private async Task<Entry> GetSearchInputEntry()
        {
            var entry = new Entry
            {
                Placeholder = await LanguageManager.GetLabelText(LabelType.TypeCoinNameLabel),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            return await Task.FromResult(entry);
        }

        private async Task<Button> GetSearchButton()
        {
            var searchButton = new Button
            {
                Text = await LanguageManager.GetLabelText(LabelType.SearchButtonLabel),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 10)
            };
            searchButton.Clicked += OnSearchButtonClicked;

            return await Task.FromResult(searchButton);
        }

        private async Task<ActivityIndicator> GetMiniLoader()
        {
            var loader = new ActivityIndicator
            {
                IsVisible = false,
                IsRunning = false,
                Color = Colors.Gray,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            return await Task.FromResult(loader);
        }

        private async Task<ListView> GetSearchResultsListView()
        {
            var searchResultsView = new ListView
            {
                ItemsSource = _suggestions,
                ItemTemplate = new DataTemplate(() =>
                {
                    var label = new Label
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    };
                    
                    label.SetBinding(Label.TextProperty, "Name");
                    var viewCell = new CustomViewCell { View = label, SelectedBackgroundColor = Colors.Transparent };

                    viewCell.Tapped += HighlightSelectedItem;

                    return viewCell;
                }),
                SeparatorColor = Colors.DarkSlateGray,
                IsVisible = false,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            searchResultsView.ItemSelected += OnSearchResultListViewItemSelected;

            return await Task.FromResult(searchResultsView);
        }

        private async Task<Image> GetCoinImage(string? url)
        {

            var image = new Image
            {
                Source = url ?? "https://plus.unsplash.com/premium_photo-1675544983459-0138e691a186",
                HeightRequest = 100,
                WidthRequest = 100,
                HorizontalOptions = LayoutOptions.Center
            };

            return await Task.FromResult(image);
        }

        private async Task<View> GetCoinInfoLabel(LabelType labelType, string? value)
        {
            var infoLabel = new Label
            {
                Text = $"{await LanguageManager.GetLabelText(labelType)}:",
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            var valueLabel = new Label
            {
                Text = value ?? "N/A",
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            var complexLabel = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = { infoLabel, valueLabel }
            };

            return await Task.FromResult(complexLabel);
        }
    }
}
