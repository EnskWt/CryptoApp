using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.LanguageFramework
{
    public class LanguageHelper
    {
        public static List<string> GetLanguagesList()
        {
            var languages = Enum.GetValues(typeof(Language))
                    .Cast<Language>()
                    .Select(lang => lang.GetDescription())
                    .ToList();

            return languages;
        }

        public static Language GetLanguageByDescription(string description)
        {
            var language = Enum.GetValues(typeof(Language))
                    .Cast<Language>()
                    .FirstOrDefault(lang => lang.GetDescription() == description);

            return language;
        }
    }
}
