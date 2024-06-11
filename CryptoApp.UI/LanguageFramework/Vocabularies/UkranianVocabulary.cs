using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.LanguageFramework.Vocabularies
{
    public class UkranianVocabulary : IVocabulary
    {
        public Language Language { get; } = Language.Polish;

        public Dictionary<LabelType, string> Labels { get; } = new Dictionary<LabelType, string>
        {
            { LabelType.SettingsLabel, "Налаштування" },
            { LabelType.ChangeAppThemeLabel, "Темний режим" },
            { LabelType.ChangeAppLanguageLabel, "Мова" },

            { LabelType.MainMenuLabel, "Головне меню" },

            { LabelType.BackButtonLabel, "Назад" },
        };

        public Dictionary<string, string> Pages { get; } = new Dictionary<string, string>
        {
            { "Main Menu", "Головне меню" },
            { "Analytics", "Аналітика" },
            { "Coin Search", "Пошук монет" },
            { "Converter", "Конвертер" },
            { "News", "Новини" },
            { "Predictions", "Прогнози" },
            { "Settings", "Налаштування" },
        };
    }
}
