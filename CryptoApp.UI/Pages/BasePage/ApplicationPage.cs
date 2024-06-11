using Microsoft.Maui.Layouts;

namespace CryptoApp.UI.Pages.BasePage
{
    public abstract partial class ApplicationPage : ContentPage
    {
        public App App => (App)Application.Current!;

        public ApplicationPage()
        {
            ConfigurePage();
            BuildPage();
        }

        private void ConfigurePage()
        {
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);

            App.StateStorage.LanguageChanged += RefreshPage;
        }

        private void BuildPage()
        {
            Content = BuildPageLayout();
        }

        protected void RefreshPage()
        {
            BuildPage();
        }

        protected virtual Layout BuildPageLayout()
        {
            var layout = new FlexLayout
            {
                Direction = FlexDirection.Column,
                JustifyContent = FlexJustify.Start,
                AlignItems = FlexAlignItems.Stretch,
                AlignContent = FlexAlignContent.Start,
            };

            var navBar = GetNavigationBar();
            layout.Children.Add(navBar);
                
            return layout;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateBackButtonVisibility();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private void UpdateBackButtonVisibility()
        {
            if (App.StateStorage.BackButton != null)
            {
                App.StateStorage.BackButton.IsVisible = Navigation.NavigationStack.Count > 1;
            }
        }
    }
}
