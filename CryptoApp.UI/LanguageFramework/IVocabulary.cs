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

        public async Task<string> GetLabelByLabelType(LabelType labelType) => await Task.FromResult(Labels.TryGetValue(labelType, out var value) ? value : string.Empty);

        public async Task<string> GetPageByPageName(string pageName) => await Task.FromResult(Pages.TryGetValue(pageName, out var value) ? value : string.Empty);
    }
}
