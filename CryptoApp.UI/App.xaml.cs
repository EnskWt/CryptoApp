using CryptoApp.Shared.LanguageStorage;
using CryptoApp.UI.LanguageFramework;
using CryptoApp.UI.Pages.MainMenuPage;
using CryptoApp.UI.State;

namespace CryptoApp.UI
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public StateStorage StateStorage { get; } = new StateStorage();

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;

            MainPage = new NavigationPage(_serviceProvider.GetRequiredService<MainMenuPage>());
        }

        protected override void OnStart()
        {
            SetAppTheme();

            SetAppLanguage();
        }

        private void SetAppTheme()
        {
            if (Current == null)
            {
                throw new InvalidOperationException($"Application.Current is null");
            }

            var savedTheme = Preferences.Get("AppTheme", "Light");

            Current.UserAppTheme = savedTheme == "Dark" ? AppTheme.Dark : AppTheme.Light;
        }

        private void SetAppLanguage()
        {
            if (Current == null)
            {
                throw new InvalidOperationException($"Application.Current is null");
            }

            var savedLanguage = Preferences.Get("AppLanguage", Language.English.ToString());
            if (!Enum.TryParse<Language>(savedLanguage, out var language))
            {
                language = Language.English;
            }

            StateStorage.CurrentLanguage = language;
        }
    }
}
