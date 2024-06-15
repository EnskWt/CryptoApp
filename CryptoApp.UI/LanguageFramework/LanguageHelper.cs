using CryptoApp.Shared.LanguageStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.LanguageFramework
{
    public class LanguageHelper
    {
        public static async Task<List<string>> GetLanguagesList()
        {
            var languages = Enum.GetValues(typeof(Language))
                    .Cast<Language>()
                    .Select(lang => lang.GetDescription())
                    .ToList();

            return await Task.FromResult(languages);
        }

        public static async Task<Language> GetLanguageByDescription(string description)
        {
            var language = Enum.GetValues(typeof(Language))
                    .Cast<Language>()
                    .FirstOrDefault(lang => lang.GetDescription() == description);

            return await Task.FromResult(language);
        }
    }
}
