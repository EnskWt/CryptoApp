using CryptoApp.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.Services.MarketAnalyticsService
{
    public interface IMarketAnalyticsService
    {
        Task<MarketDataViewModel> GetGlobalMarketData();
    }
}
