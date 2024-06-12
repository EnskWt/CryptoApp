using CryptoApp.UI.Attributes;
using CryptoApp.UI.LanguageFramework;

namespace CryptoApp.UI.Helpers
{
    public class PageHelper
    {
        public static async Task<string> GetPageTitle(Type pageType)
        {
            var pageTitleAttribute = (PageTitleAttribute?)Attribute.GetCustomAttribute(pageType, typeof(PageTitleAttribute));
            return await LanguageManager.GetPageName(pageTitleAttribute?.Title ?? pageType.Name);
        }
    }
}
