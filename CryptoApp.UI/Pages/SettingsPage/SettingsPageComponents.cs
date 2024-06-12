using CryptoApp.UI.LanguageFramework;
using CryptoApp.UI.Pages.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Pages.SettingsPage
{
    public partial class SettingsPage : ApplicationPage
    {
        private async Task<Switch> GetThemeSwitch()
        {
            var themeSwitch = new Switch
            {
                IsToggled = Application.Current?.UserAppTheme == AppTheme.Dark,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            themeSwitch.Toggled += OnThemeSwitchToggled;

            return await Task.FromResult(themeSwitch);
        }

        private async Task<Picker> GetLanguagePicker()
        {
            var languages = await LanguageHelper.GetLanguagesList();

            var languagePicker = new Picker
            {
                ItemsSource = languages,
                SelectedIndex = languages.IndexOf(App.StateStorage.CurrentLanguage.GetDescription()),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            languagePicker.SelectedIndexChanged += OnLanguagePickerSelectedIndexChanged;

            return await Task.FromResult(languagePicker);
        }
    }
}
