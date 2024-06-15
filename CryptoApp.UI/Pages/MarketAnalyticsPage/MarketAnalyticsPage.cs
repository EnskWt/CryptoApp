using CryptoApp.Services.Services.MarketAnalyticsService;
using CryptoApp.UI.Attributes;
using CryptoApp.UI.Pages.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Pages.MarketAnalyticsPage
{
    [PageTitle("Analytics")]
    public partial class MarketAnalyticsPage : ApplicationPage
    {
        private readonly IMarketAnalyticsService MarketAnalyticsService;

        public MarketAnalyticsPage(IMarketAnalyticsService marketAnalyticsService)
        {
            MarketAnalyticsService = marketAnalyticsService;
        }

        protected override async Task<Layout> BuildPageLayout()
        {
            var appLayout = await base.BuildPageLayout();

            var mainLayout = await GetAnalyticsSection();

            appLayout.Children.Add(mainLayout);

            return appLayout;
        }
    }
}
 