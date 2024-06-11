using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.LanguageFramework
{
    public interface IVocabulary
    {
        Language Language { get; }

        Dictionary<LabelType, string> Labels { get; }
        
        Dictionary<string, string> Pages { get; }

        public string GetLabelByLabelType(LabelType labelType) => Labels.TryGetValue(labelType, out var value) ? value : string.Empty;

        public string GetPageByPageName(string pageName) => Pages.TryGetValue(pageName, out var value) ? value : string.Empty;
    }
}
