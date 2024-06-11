using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PageTitleAttribute : Attribute
    {
        public string Title { get; }

        public PageTitleAttribute(string title)
        {
            Title = title;
        }
    }
}
