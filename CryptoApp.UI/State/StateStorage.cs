using CryptoApp.UI.LanguageFramework;
using CryptoApp.UI.Pages;

/* Необъединенное слияние из проекта "CryptoApp.UI (net8.0-windows10.0.19041.0)"
До:
using System;
После:
using CryptoApp.UI.Pages.SettingsPage;
using System;
*/

/* Необъединенное слияние из проекта "CryptoApp.UI (net8.0-android)"
До:
using System;
После:
using CryptoApp.UI.Pages.SettingsPage;
using CryptoApp.UI.Pages.SettingsPage.SettingsPage;
using System;
*/

/* Необъединенное слияние из проекта "CryptoApp.UI (net8.0-ios)"
До:
using System;
После:
using CryptoApp.UI.Pages.SettingsPage;
using CryptoApp.UI.Pages.SettingsPage.SettingsPage;
using CryptoApp.UI.Pages.SettingsPage.SettingsPage.SettingsPage;
using System;
*/
using CryptoApp.UI.Pages.SettingsPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.State
{
    public class StateStorage
    {
        #region Language 

        private Language _currentLanguage;
        public Language CurrentLanguage { 
            get => _currentLanguage;
            set
            {
                if (_currentLanguage != value)
                {
                    _currentLanguage = value;
                    OnLanguageChanged();
                }
            }
        }

        public event Action LanguageChanged = null!;

        private void OnLanguageChanged()
        {
            LanguageChanged?.Invoke();
        }

        #endregion

        #region BackButton

        public Button? BackButton { get; set; }

        #endregion

        #region MenuOptions

        public List<Type> MainMenuOptions { get; } = new List<Type>()
        {
            typeof(AnalyticsPage),
            typeof(PredictionsPage),
            typeof(CoinSearchPage),
            typeof(ConverterPage),
            typeof(NewsPage),
            typeof(SettingsPage)
        };

        #endregion
    }
}
