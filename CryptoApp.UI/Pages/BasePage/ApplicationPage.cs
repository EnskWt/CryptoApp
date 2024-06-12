using CryptoApp.UI.State;
using Microsoft.Maui.Layouts;

namespace CryptoApp.UI.Pages.BasePage
{
    public abstract partial class ApplicationPage : ContentPage
    {
        public App App => (App)Application.Current!;

        private ContentView _contentView = null!;
        private ActivityIndicator _loader = null!;

        public ApplicationPage()
        {
            ConfigurePage();
            CreatePage();
        }

        private async void ConfigurePage()
        {
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);

            App.StateStorage.LanguageChanged += RefreshPage;
            App.StateStorage.ShowLoaderChanged += UpdateLoaderVisibility;


            await Task.CompletedTask;
        }

        private async void CreatePage()
        {
            _loader = await GetLoader();

            _contentView = new ContentView();

            var mainLayout = new Grid
            {
                Children =
                {
                    _contentView,
                    _loader
                }
            };

            Content = mainLayout;

            await Task.CompletedTask;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await BuildPage();
            await UpdateBackButtonVisibility();
        }

        private async Task BuildPage()
        {
            App.StateStorage.ShowLoader = true;
            _contentView.Content = await BuildPageLayout();
            App.StateStorage.ShowLoader = false;
            await Task.CompletedTask;
        }

        protected async void UpdateLoaderVisibility()
        {
            if (_loader != null)
            {
                _loader.IsRunning = App.StateStorage.ShowLoader;
                _loader.IsVisible = App.StateStorage.ShowLoader;
            }

            await Task.CompletedTask;
        }

        protected async void RefreshPage()
        {
            await BuildPage();
        }

        protected virtual async Task<Layout> BuildPageLayout()
        {
            var layout = new FlexLayout
            {
                Direction = FlexDirection.Column,
                JustifyContent = FlexJustify.Start,
                AlignItems = FlexAlignItems.Stretch,
                AlignContent = FlexAlignContent.Start,
            };

            var navBar = await GetNavigationBar();

            layout.Children.Add(navBar);

            return layout;
        }

        private async Task UpdateBackButtonVisibility()
        {
            if (App.StateStorage.BackButton != null)
            {
                App.StateStorage.BackButton.IsVisible = Navigation.NavigationStack.Count > 1;
            }

            await Task.CompletedTask;
        }
    }
}
