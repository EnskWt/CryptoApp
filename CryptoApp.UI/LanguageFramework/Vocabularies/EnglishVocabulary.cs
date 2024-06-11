using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.LanguageFramework.Vocabularies
{
    public class EnglishVocabulary : IVocabulary
    {
        public Language Language { get; } = Language.English;

        public Dictionary<LabelType, string> Labels { get; } = new Dictionary<LabelType, string>
        {
            { LabelType.SettingsLabel, "Settings" },
            { LabelType.ChangeAppThemeLabel, "Dark Mode" },
            { LabelType.ChangeAppLanguageLabel, "Language" },

            { LabelType.MainMenuLabel, "Main Menu" },

            { LabelType.BackButtonLabel, "Back" },
        };

        public Dictionary<string, string> Pages { get; } = new Dictionary<string, string>
        {
            { "Main Menu", "Main Menu" },
            { "Analytics", "Analytics" },
            { "Coin Search", "Coin Search" },
            { "Converter", "Converter" },
            { "News", "News" },
            { "Predictions", "Predictions" },
            { "Settings", "Settings" },
        };
    }
}
