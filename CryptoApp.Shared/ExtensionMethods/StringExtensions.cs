using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Shared.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string ToMathStringWithSuffix(this double value, char suffix)
        {
            var units = new[] { "", "k", "M", "B", "T" };
            int order = 0;
            while (value >= 1000 && order < units.Length - 1)
            {
                order++;
                value /= 1000;
            }

            return string.Format("{0}{1}{2}", value.ToString("0.##"), units[order], suffix);
        }

        public static string ToStringWithSuffix(this int value, char suffix)
        {
            return string.Format("{0}{1}", suffix, value.ToString());
        }
    }
}
