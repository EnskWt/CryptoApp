using CryptoApp.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.Services.ConverterService
{
    public interface IConverterService
    {
        Task<ConvertResultViewModel> ConvertCurrency(string inputCurrency, string outputCurrency, double inputAmount);
    }
}
