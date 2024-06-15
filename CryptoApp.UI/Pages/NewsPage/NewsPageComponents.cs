using CryptoApp.Services.ViewModels;
using CryptoApp.UI.Pages.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Pages.NewsPage
{
    public partial class NewsPage : ApplicationPage
    {
        private async Task<StackLayout> GetNewsSection()
        {
            var newsList = await _newsService.GetAllNews(App.StateStorage.CurrentLanguage);

            var sectionLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Margin = new Thickness(10)
            };

            foreach (var news in newsList)
            {
                var frame = new Frame
                {
                    BackgroundColor = Colors.LightGray,
                    CornerRadius = 10,
                    WidthRequest = 350,
                    HorizontalOptions = LayoutOptions.Center
                };

                var innerStack = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                };

                var titleLabel = new Label
                {
                    Text = news.Title,
                    FontSize = 20,
                    FontAttributes = FontAttributes.Bold
                };

                var descriptionLabel = new Label
                {
                    Text = news.Description,
                    FontSize = 14,
                };

                innerStack.Children.Add(titleLabel);
                innerStack.Children.Add(descriptionLabel);

                frame.Content = innerStack;

                sectionLayout.Children.Add(frame);
            }

            return await Task.FromResult(sectionLayout);
        }
    }
}
