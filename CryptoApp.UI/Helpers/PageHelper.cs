using CryptoApp.UI.Attributes;
using CryptoApp.UI.LanguageFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Helpers
{
    public class PageHelper
    {
        public static string GetPageTitle(Type pageType)
        {
            var pageTitleAttribute = (PageTitleAttribute?)Attribute.GetCustomAttribute(pageType, typeof(PageTitleAttribute));
            return LanguageManager.GetPageName(pageTitleAttribute?.Title ?? pageType.Name);
        }
    }
}
