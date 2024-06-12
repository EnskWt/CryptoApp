using CryptoApp.UI.Attributes;
using CryptoApp.UI.Pages.BasePage;

namespace CryptoApp.UI.Pages;

[PageTitle("Converter")]
public class ConverterPage : ApplicationPage
{
    protected override async Task<Layout> BuildPageLayout()
    {
        var appLayout = await base.BuildPageLayout();

        return appLayout;
    }
}