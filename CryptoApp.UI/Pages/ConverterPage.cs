using CryptoApp.UI.Attributes;
using CryptoApp.UI.Pages.BasePage;

namespace CryptoApp.UI.Pages;

[PageTitle("Converter")]
public class ConverterPage : ApplicationPage
{
	public ConverterPage()
	{
        var stackLayout = new StackLayout
        {
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
        };

        var label = new Label
        {
            Text = "ConverterPage",
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