using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Shared.LanguageStorage
{
    public enum Language
    {
        [Description("English")]
        English,

        [Description("Polski")]
        Polish,

        [Description("Українська")]
        Ukranian
    }

    public static class LanguageEnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            if (field == null)
            {
                return value.ToString();
            }

            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? value.ToString();
        }
    }
}
