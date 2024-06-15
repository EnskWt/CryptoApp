using CryptoApp.Services.ViewModels;
using CryptoApp.UI.LanguageFramework;
using CryptoApp.UI.Pages.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Pages.MarketAnalyticsPage
{
    public partial class MarketAnalyticsPage : ApplicationPage
    {
        private async Task<StackLayout> GetGlobalMarketDataLabel(LabelType labelType, string? value)
        {
            var dataLabel = new Label
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
                Children = { dataLabel, valueLabel }
            };

            return await Task.FromResult(complexLabel);
        }

        private async Task<Label> GetCoinInfoLabel(ShortCoinViewModel coin)
        {
            var label = new Label
            {
                Text = $"{coin.Name}",
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                MaxLines = 1
            };

            return await Task.FromResult(label);
        }


        private async Task<StackLayout> GetAnalyticsSection()
        {
            var globalMarketData = await MarketAnalyticsService.GetGlobalMarketData();

            var analyticsSection = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Margin = new Thickness(15),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Children =
                {
                    await GetMarketInfoSection(globalMarketData.GlobalMarketData),
                    await GetTopCoinsSection(globalMarketData.TopCoins),
                    await GetRecommendedCoinsSection(globalMarketData.RecommendedCoins)
                }
            };

            return await Task.FromResult(analyticsSection);
        }

        private async Task<Frame> GetMarketInfoSection(GlobalMarketDataViewModel? globalMarketData)
        {
            var marketInfoLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Children =
                {
                    await GetLargeLabel(LabelType.GlobalMarketDataLabel),
                    await GetGlobalMarketDataLabel(LabelType.ActiveCryptocurrenciesCountLabel, globalMarketData?.ActiveCryptocurrenciesCount),
                    await GetGlobalMarketDataLabel(LabelType.MarketsCountLabel, globalMarketData?.MarketsCount),
                    await GetGlobalMarketDataLabel(LabelType.MarketCapChangePercentageLabel, globalMarketData?.MarketCapChangePercentage),
                    await GetGlobalMarketDataLabel(LabelType.UpcomingIcosCountLabel, globalMarketData?.UpcomingIcosCount),
                    await GetGlobalMarketDataLabel(LabelType.OngoingIcosCountLabel, globalMarketData?.OngoingIcosCount),
                    await GetGlobalMarketDataLabel(LabelType.EndedIcosCountLabel, globalMarketData?.EndedIcosCount),
                    await GetGlobalMarketDataLabel(LabelType.TotalVolumeLabel, globalMarketData?.TotalVolume),
                }
            };

            var marketInfoFrame = new Frame
            {
                CornerRadius = 10,
                HasShadow = true,
                Content = marketInfoLayout
            };

            return await Task.FromResult(marketInfoFrame);
        }

        private async Task<Frame> GetTopCoinsSection(List<ShortCoinViewModel>? topCoins)
        {
            if (topCoins == null || topCoins.Count == 0)
            {
                return new Frame();
            }

            var topCoinsLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Children =
                {
                    await GetLargeLabel(LabelType.TopCoinsLabel),
                }
            };

            foreach (var coin in topCoins)
            {
                topCoinsLayout.Children.Add(await GetCoinInfoLabel(coin));
            }

            var topCoinsFrame = new Frame
            {
                CornerRadius = 10,
                HasShadow = true,
                Content = topCoinsLayout
            };

            return await Task.FromResult(topCoinsFrame);
        }

        private async Task<Frame> GetRecommendedCoinsSection(List<ShortCoinViewModel>? recommendedCoins)
        {
            if (recommendedCoins == null || recommendedCoins.Count == 0)
            {
                return new Frame();
            }

            var recommendedCoinsLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Children =
                {
                    await GetLargeLabel(LabelType.RecommendedCoinsLabel),
                }
            };

            foreach (var coin in recommendedCoins)
            {
                recommendedCoinsLayout.Children.Add(await GetCoinInfoLabel(coin));
            }

            var recommendedCoinsFrame = new Frame
            {
                CornerRadius = 10,
                HasShadow = true,
                Content = recommendedCoinsLayout
            };

            return await Task.FromResult(recommendedCoinsFrame);
        }
    }
}
