using CryptoApp.Services.CoinSearchService;
using CryptoApp.UI.Attributes;
using CryptoApp.UI.Pages.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            var mainLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Margin = new Thickness(10),
            };

            var coinPicker = await CreateCoinPicker();

            mainLayout.Children.Add(new Label
            {
                Text = "Select a Coin",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center
            });
            mainLayout.Children.Add(coinPicker);


            appLayout.Children.Add(mainLayout);

            return appLayout;
        }
    }
}
