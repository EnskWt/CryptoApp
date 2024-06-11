using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.LanguageFramework.Vocabularies
{
    public class PolishVocabulary : IVocabulary
    {
        public Language Language { get; } = Language.Polish;

        public Dictionary<LabelType, string> Labels { get; } = new Dictionary<LabelType, string>
        {
            { LabelType.SettingsLabel, "Ustawenia" },
            { LabelType.ChangeAppThemeLabel, "Tryb ciemny" },
            { LabelType.ChangeAppLanguageLabel, "Język" },

            { LabelType.MainMenuLabel, "Menu główne" },

            { LabelType.BackButtonLabel, "Wstecz" },
        };

        public Dictionary<string, string> Pages { get; } = new Dictionary<string, string>
        {
            { "Main Menu", "Menu główne" },
            { "Analytics", "Analityka" },
            { "Coin Search", "Wyszukiwanie" },
            { "Converter", "Konwerter" },
            { "News", "Aktualności" },
            { "Predictions", "Przewidywania" },
            { "Settings", "Ustawienia" },
        };
    }
}
