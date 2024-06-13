using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.ViewModels
{
    public class ConvertResultViewModel
    {
        public string? InputCurrencyName { get; set; }
        public string? OutputCurrencyName { get; set; }
        public string? InputAmount { get; set; }
        public string? OutputAmount { get; set; }
    }
}
