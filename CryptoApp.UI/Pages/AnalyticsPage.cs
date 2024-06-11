using CryptoApp.UI.Attributes;
using CryptoApp.UI.Pages.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Pages
{
    [PageTitle("Analytics")]
    public class AnalyticsPage : ApplicationPage
    {
        public AnalyticsPage()
        {
            var stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            var label = new Label
            {
                Text = "AnalyticsPage",
                FontSize = 24
            };

            stackLayout.Children.Add(label);

            Content = stackLayout;
        }

        protected override Layout BuildPageLayout()
        {
            var appLayout = base.BuildPageLayout();

            return appLayout;
        }
    }
}
