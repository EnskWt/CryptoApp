using CryptoApp.UI.Helpers;
using CryptoApp.UI.LanguageFramework;

namespace CryptoApp.UI.Pages.BasePage
{
    public abstract partial class ApplicationPage : ContentPage
    {
        #region Reusable components

        protected Label GetBigLabel(LabelType labelType)
        {
            return new Label
            {
                Text = LanguageManager.GetLabelText(labelType),
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
        }

        protected Label GetMediumLabel(LabelType labelType)
        {
            return new Label
            {
                Text = LanguageManager.GetLabelText(labelType),
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
        }

        #endregion


        #region Specific components

        private View GetNavigationBar()
        {
            var navBar = new Grid
            {
                BackgroundColor = new Color(0.9f, 0.9f, 0.9f, 0.5f),
                HeightRequest = 50,
                Padding = new Thickness(0, 0)
            };

            navBar.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            navBar.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            var backButton = GetBackButton();
            if (backButton != null)
            {
                navBar.Children.Add(backButton);
                Grid.SetColumn(backButton, 0);
            }

            var titleLabel = GetPageTitleLabel();
            if (titleLabel != null)
            {
                navBar.Children.Add(titleLabel);
                Grid.SetColumn(titleLabel, 1);
            }

            return navBar;
        }

        private View GetBackButton()
        {
            var backButton = new Button
            {
                Text = LanguageManager.GetLabelText(LabelType.BackButtonLabel),
                FontSize = 14,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Colors.Transparent,
                TextColor = Colors.Black,
                IsVisible = Navigation.NavigationStack.Count > 1
            };

            backButton.Clicked += async (sender, e) => await Navigation.PopAsync();
             
            App.StateStorage.BackButton = backButton;

            return backButton;
        }

        private Label GetPageTitleLabel()
        {
            var titleLabel = new Label
            {
                Text = PageHelper.GetPageTitle(GetType()),
                FontSize = 22,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Colors.Transparent,
                Padding = new Thickness(0, 0, 15, 0)
            };

            return titleLabel;
        }

        #endregion
    }
}
