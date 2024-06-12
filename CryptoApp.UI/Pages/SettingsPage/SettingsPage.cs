using CryptoApp.UI.Attributes;
using CryptoApp.UI.LanguageFramework;
using CryptoApp.UI.Pages.BasePage;
using CryptoApp.UI.State;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Pages.SettingsPage
{
    [PageTitle("Settings")]
    public partial class SettingsPage : ApplicationPage
    {
        protected override async Task<Layout> BuildPageLayout()
        {
            var appLayout = await base.BuildPageLayout();

            var themeLabel = await GetMediumLabel(LabelType.ChangeAppThemeLabel);

            var themeSwitch = await GetThemeSwitch();

            var themeLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Children = { themeLabel, themeSwitch }
            };

            var languageLabel = await GetMediumLabel(LabelType.ChangeAppLanguageLabel);

            var languagePicker = await GetLanguagePicker();

            var languageLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Children = { languageLabel, languagePicker }
            };

            var mainLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Margin = new Thickness(10),
                Children = { themeLayout, languageLayout },
            };

            appLayout.Children.Add(mainLayout);

            return appLayout;
        }

        private async void OnThemeSwitchToggled(object? sender, ToggledEventArgs e)
        {
            if (Application.Current == null)
            {
                throw new NullReferenceException("App.Current is null");
            }

            if (sender == null)
            {
                throw new NullReferenceException("sender is null");
            }

            Preferences.Set("AppTheme", e.Value ? "Dark" : "Light");

            Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;

            await Task.CompletedTask;
        }

        private async void OnLanguagePickerSelectedIndexChanged(object? sender, EventArgs e)
        {
            if (sender == null)
            {
                throw new NullReferenceException("sender is null");
            }

            var picker = (Picker)sender;

            if (picker.SelectedIndex == -1)
            {
                return;
            }

            var selectedLanguage = picker.Items[picker.SelectedIndex];

            var language = await LanguageHelper.GetLanguageByDescription(selectedLanguage);

            Preferences.Set("AppLanguage", language.ToString());
            App.StateStorage.CurrentLanguage = language;

            await Task.CompletedTask;
        }
    }
}
