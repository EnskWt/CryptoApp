using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.ExtensionMethods
{
    public static class StringExtensions
    {
        public static FormattedString ToFormattedString(this string text, TextDecorations decorations)
        {
            return new FormattedString
            {
                Spans = { new Span { Text = text, TextDecorations = decorations } }
            };
        }
    }
}
