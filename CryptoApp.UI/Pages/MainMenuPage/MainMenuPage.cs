using CryptoApp.UI.Attributes;
using CryptoApp.UI.Pages.BasePage;
using Microsoft.Maui.Layouts;

namespace CryptoApp.UI.Pages.MainMenuPage
{
    [PageTitle("Main Menu")]
    public partial class MainMenuPage : ApplicationPage
    {
        private readonly IServiceProvider _serviceProvider;

        private List<Type> _optionPages => App.StateStorage.MainMenuOptions;

        public MainMenuPage(IServiceProvider serviceProvider) : base()
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task<Layout> BuildPageLayout()
        {
            var appLayout = await base.BuildPageLayout();

            var mainLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(10),
            };

            var buttonLayout = new Grid
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            int numberOfColumns = 2;
            int numberOfRows = 3;

            for (int i = 0; i < numberOfColumns; i++)
            {
                buttonLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < numberOfRows; i++)
            {
                buttonLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            }

            int row = 0;
            int column = 0;

            foreach (var pageType in _optionPages)
            {
                var button = await GetMenuOptionButton(pageType);

                buttonLayout.Children.Add(button);
                Grid.SetRow(button, row);
                Grid.SetColumn(button, column);

                column++;

                if (column >= numberOfColumns)
                {
                    column = 0;
                    row++;
                }
            }

            mainLayout.Children.Add(buttonLayout);

            appLayout.Children.Add(mainLayout);

            return appLayout;
        }

        private async Task OnMenuOptionButtonClicked(Type pageType)
        {
            var page = (Page?)_serviceProvider.GetService(pageType);
            if (page == null)
            {
                throw new NullReferenceException("Page is not found");
            }
            await Navigation.PushAsync(page);
        }
    }
}