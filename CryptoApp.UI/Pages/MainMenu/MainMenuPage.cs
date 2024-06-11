using CryptoApp.UI.Attributes;
using CryptoApp.UI.Pages.BasePage;
using Microsoft.Maui.Layouts;

namespace CryptoApp.UI.Pages.MainMenu
{
    [PageTitle("Main Menu")]
    public partial class MainMenuPage : ApplicationPage
    {
        private List<Type> _optionPages => App.StateStorage.MainMenuOptions;

        //protected override Layout BuildPageLayout()
        //{
        //    var appLayout = base.BuildPageLayout();

        //    var mainLayout = new FlexLayout
        //    {
        //        Direction = FlexDirection.Column,
        //        JustifyContent = FlexJustify.Center,
        //        AlignItems = FlexAlignItems.Center,
        //        AlignContent = FlexAlignContent.Center,
        //    };

        //    var buttonLayout = new FlexLayout
        //    {
        //        Direction = FlexDirection.Row,
        //        Wrap = FlexWrap.Wrap,
        //        JustifyContent = FlexJustify.Center,
        //        AlignItems = FlexAlignItems.Center,
        //        AlignContent = FlexAlignContent.Center
        //    };

        //    foreach (var pageType in _optionPages)
        //    {
        //        var button = GetMenuOptionButton(pageType);
        //        buttonLayout.Children.Add(button);
        //    }

        //    mainLayout.Children.Add(buttonLayout);
        //    appLayout.Children.Add(mainLayout);

        //    return appLayout;
        //}

        protected override Layout BuildPageLayout()
        {
            var appLayout = base.BuildPageLayout();

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
                var button = GetMenuOptionButton(pageType);

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
            var page = (Page?)Activator.CreateInstance(pageType);
            await Navigation.PushAsync(page);
        }
    }
}