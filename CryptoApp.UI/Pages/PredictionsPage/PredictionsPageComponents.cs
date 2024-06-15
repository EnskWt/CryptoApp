using CryptoApp.UI.LanguageFramework;
using CryptoApp.UI.Pages.BasePage;
using OxyPlot.Maui.Skia;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoApp.Shared.ExtensionMethods;
using OxyPlot.Axes;

namespace CryptoApp.UI.Pages.PredictionsPage
{
    public partial class PredictionsPage : ApplicationPage
    {
        private StackLayout _chartLayout = null!;

        private Entry _searchEntry = null!;
        private Button _searchButton = null!;

        private async Task<Entry> GetSearchEntry()
        {
            var searchEntry = new Entry
            {
                Placeholder = await LanguageManager.GetLabelText(LabelType.InputCurrencyLabel),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 125,
                HeightRequest = 50,
                Margin = new Thickness(5)
            };

            return await Task.FromResult(searchEntry);
        }

        private async Task<Button> GetSearchButton()
        {
            var searchButton = new Button
            {
                Text = await LanguageManager.GetLabelText(LabelType.SearchButtonLabel),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 125,
                HeightRequest = 50,
                Margin = new Thickness(5)
            };

            searchButton.Clicked += OnSearchButtonClicked;

            return await Task.FromResult(searchButton);
        }

        private async Task<StackLayout> GetSearchCoinChartDataLayout()
        {
            _searchEntry = await GetSearchEntry();

            _searchButton = await GetSearchButton();

            var searchLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                Margin = new Thickness(10),
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    _searchEntry,
                    _searchButton
                }
            };

            return await Task.FromResult(searchLayout);
        }

        private async Task<StackLayout> BuildChartsLayout()
        {
            var chartLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(10)
            };

            return await Task.FromResult(chartLayout);
        }

        private async Task<StackLayout> BuildChart(LabelType labelType, List<List<double>>? data)
        {
            var points = data?.Select(p => new DataPoint(DateTimeAxis.ToDouble(DateTimeOffset.FromUnixTimeMilliseconds((long)p[0]).UtcDateTime), p[1])).ToList();

            var plotModel = new PlotModel
            {
                Title = await LanguageManager.GetLabelText(labelType),
                Background = OxyColor.FromRgb(255, 255, 255)
            };

            plotModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Title = await LanguageManager.GetLabelText(LabelType.ChartTimeAxisLabel),
                StringFormat = "MMM dd",
                IntervalType = DateTimeIntervalType.Days,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
            });

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = await LanguageManager.GetLabelText(LabelType.ChartPriceAxisLabel),
                StringFormat = "$0.00",
                LabelFormatter = value => value.ToMathStringWithSuffix('$')
            });

            var lineSeries = new LineSeries
            {
                ItemsSource = points,
                Color = OxyColor.FromRgb(255, 87, 34),
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColor.FromRgb(255, 87, 34),
                
            };

            plotModel.Series.Add(lineSeries);

            var plotView = new PlotView
            {
                Model = plotModel,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                HeightRequest = 300,
                WidthRequest = 400
            };

            var chartLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(10),
                Children =
                {
                    plotView
                }
            };

            return await Task.FromResult(chartLayout);
        }
    }
}
