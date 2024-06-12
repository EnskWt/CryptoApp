using CryptoApp.UI.Helpers;
using CryptoApp.UI.LanguageFramework;

namespace CryptoApp.UI.Pages.BasePage
{
    public abstract partial class ApplicationPage : ContentPage
    {
        #region Reusable components

        protected async Task<Label> GetBigLabel(LabelType labelType)
        {
            var label = new Label
            {
                Text = await LanguageManager.GetLabelText(labelType),
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            return await Task.FromResult(label);
        }

        protected async Task<Label> GetMediumLabel(LabelType labelType)
        {
            var label = new Label
            {
                Text = await LanguageManager.GetLabelText(labelType),
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            return await Task.FromResult(label);
        }

        #endregion


        #region Specific components

        private async Task<View> GetNavigationBar()
        {
            var navBar = new Grid
            {
                BackgroundColor = new Color(0.9f, 0.9f, 0.9f, 0.5f),
                HeightRequest = 50,
                Padding = new Thickness(0, 0)
            };

            navBar.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            navBar.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            var backButton = await GetBackButton();
            if (backButton != null)
            {
                navBar.Children.Add(backButton);
                Grid.SetColumn(backButton, 0);
            }

            var titleLabel = await GetPageTitleLabel();
            if (titleLabel != null)
            {
                navBar.Children.Add(titleLabel);
                Grid.SetColumn(titleLabel, 1);
            }

            return await Task.FromResult(navBar);
        }

        private async Task<ActivityIndicator> GetLoader()
        {
            var loader = new ActivityIndicator
            {
                IsRunning = false,
                IsVisible = false,
                Color = Colors.Blue,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            return await Task.FromResult(loader);
        }

        private async Task<View> GetBackButton()
        {
            var backButton = new Button
            {
                Text = await LanguageManager.GetLabelText(LabelType.BackButtonLabel),
                FontSize = 14,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Colors.Transparent,
                TextColor = Colors.Black,
                IsVisible = Navigation.NavigationStack.Count > 1
            };

            backButton.Clicked += async (sender, e) => await Navigation.PopAsync();
             
            App.StateStorage.BackButton = backButton;

            return await Task.FromResult(backButton);
        }

        private async Task<Label> GetPageTitleLabel()
        {
            var titleLabel = new Label
            {
                Text = await PageHelper.GetPageTitle(GetType()),
                FontSize = 22,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Colors.Transparent,
                Padding = new Thickness(0, 0, 15, 0)
            };

            return await Task.FromResult(titleLabel);
        }

        #endregion
    }
}
