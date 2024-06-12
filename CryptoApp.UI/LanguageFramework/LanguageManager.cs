using CryptoApp.UI.LanguageFramework.Vocabularies;
using CryptoApp.UI.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.LanguageFramework
{
    public class LanguageManager
    {
        private static Dictionary<Language, IVocabulary> vocabularies = new Dictionary<Language, IVocabulary>()
        {
            { Language.English, new EnglishVocabulary() },
            { Language.Polish, new PolishVocabulary() },
            { Language.Ukranian, new UkranianVocabulary() }
        };

        public static async Task<string> GetLabelText(LabelType label)
        {
            var language = ((App)Application.Current!).StateStorage.CurrentLanguage;
            var requiredVocabulary = vocabularies[language];
            if (requiredVocabulary == null)
            {
                throw new Exception("Vocabulary not found for language: " + language);
            }

            return await requiredVocabulary.GetLabelByLabelType(label);
        }

        public static async Task<string> GetPageName(string pageName)
        {
            var language = ((App)Application.Current!).StateStorage.CurrentLanguage;
            var requiredVocabulary = vocabularies[language];
            if (requiredVocabulary == null)
            {
                throw new Exception("Vocabulary not found for language: " + language);
            }

            return await requiredVocabulary.GetPageByPageName(pageName);
        }
    }
}
