using CryptoApp.Services.Services.PredictionsService;
using CryptoApp.UI.Attributes;
using CryptoApp.UI.LanguageFramework;
using CryptoApp.UI.Pages.BasePage;
using OxyPlot;
using OxyPlot.Maui.Skia;
using OxyPlot.Series;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Pages.PredictionsPage
{
    [PageTitle("Predictions")]
    public partial class PredictionsPage : ApplicationPage
    {
        private readonly IPredictionsService _predictionsService;

        public PredictionsPage(IPredictionsService predictionsService) : base()
        {
            _predictionsService = predictionsService;
        }

        protected override async Task<Layout> BuildPageLayout()
        {
            var appLayout = await base.BuildPageLayout();

            var searchLayout = await GetSearchCoinChartDataLayout();

            _chartLayout = await BuildChartsLayout();

            appLayout.Children.Add(searchLayout);
            appLayout.Children.Add(_chartLayout);

            return appLayout;
        }

        private async void OnSearchButtonClicked(object? sender, EventArgs e)
        {
            await ShowLoader();
            _searchButton.IsEnabled = false;
            _searchEntry.IsEnabled = false;

            await LoadCharts();

            _searchButton.IsEnabled = true;
            _searchEntry.IsEnabled = true;
            await HideLoader();
        }

        private async Task LoadCharts()
        {
            var inputCoin = _searchEntry.Text;

            var marketChartData = await _predictionsService.GetMarketChartData(inputCoin);

            var pricesChart = await BuildChart(LabelType.PricesChartLabel, marketChartData.Prices);

            var marketCapsChart = await BuildChart(LabelType.MarketCapsChartLabel, marketChartData.MarketCaps);

            var totalVolumesChart = await BuildChart(LabelType.TotalVolumesChartLabel, marketChartData.TotalVolumes);

            var chartsLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 10,
                Children =
                {
                    pricesChart,
                    marketCapsChart,
                    totalVolumesChart
                }
            };

            _chartLayout.Children.Clear();
            _chartLayout.Children.Add(chartsLayout);

            _searchEntry.Text = marketChartData.CoinName;
        }
    }
}
