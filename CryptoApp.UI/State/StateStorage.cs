using CryptoApp.UI.LanguageFramework;
using CryptoApp.UI.Pages;
using CryptoApp.UI.Pages.CoinSearchPage;
using CryptoApp.UI.Pages.ConverterPage;
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

        #region Loader

        private bool _showLoader;
        public bool ShowLoader
        {
            get => _showLoader;
            set
            {
                if (_showLoader != value)
                {
                    _showLoader = value;
                    OnShowLoaderChanged();
                }
            }
        }

        public event Action ShowLoaderChanged = null!;

        private void OnShowLoaderChanged()
        {
            ShowLoaderChanged?.Invoke();
        }

        #endregion
    }
}
