using CryptoApp.UI;
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
        protected override async Task<Layout> BuildPageLayout()
        {
            var appLayout = await base.BuildPageLayout();

            return appLayout;
        }
    }
}
