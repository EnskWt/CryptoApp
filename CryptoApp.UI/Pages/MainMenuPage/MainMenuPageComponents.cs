using CryptoApp.UI.Helpers;
using CryptoApp.UI.Pages.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Pages.MainMenuPage
{
    public partial class MainMenuPage : ApplicationPage
    {
        private async Task<Button> GetMenuOptionButton(Type pageType)
        {
            var button = new Button
            {
                Text = await PageHelper.GetPageTitle(pageType),
                CornerRadius = 10,
                BackgroundColor = Color.FromRgb(211, 211, 211),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 150,
                HeightRequest = 150,
                Margin = new Thickness(10)
            };

            button.Clicked += async (sender, e) => await OnMenuOptionButtonClicked(pageType);

            return await Task.FromResult(button);
        }
    }
}
