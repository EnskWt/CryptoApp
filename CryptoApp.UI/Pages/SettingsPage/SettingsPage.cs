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
        protected override Layout BuildPageLayout()
        {
            var appLayout = base.BuildPageLayout();

            var themeLabel = GetMediumLabel(LabelType.ChangeAppThemeLabel);

            var themeSwitch = GetThemeSwitch();

            var themeLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Children = { themeLabel, themeSwitch }
            };

            var languageLabel = GetMediumLabel(LabelType.ChangeAppLanguageLabel);

            var languagePicker = GetLanguagePicker();

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

        private void OnThemeSwitchToggled(object? sender, ToggledEventArgs e)
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
        }

        private void OnLanguagePickerSelectedIndexChanged(object? sender, EventArgs e)
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

            var language = LanguageHelper.GetLanguageByDescription(selectedLanguage);

            Preferences.Set("AppLanguage", language.ToString());
            App.StateStorage.CurrentLanguage = language;
        }
    }
}
