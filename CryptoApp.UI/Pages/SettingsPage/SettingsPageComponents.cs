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
        private Switch GetThemeSwitch()
        {
            var themeSwitch = new Switch
            {
                IsToggled = Application.Current?.UserAppTheme == AppTheme.Dark,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            themeSwitch.Toggled += OnThemeSwitchToggled;

            return themeSwitch;
        }

        private Picker GetLanguagePicker()
        {
            var languages = LanguageHelper.GetLanguagesList();

            var languagePicker = new Picker
            {
                ItemsSource = languages,
                SelectedIndex = languages.IndexOf(App.StateStorage.CurrentLanguage.GetDescription()),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            languagePicker.SelectedIndexChanged += OnLanguagePickerSelectedIndexChanged;

            return languagePicker;
        }
    }
}
