using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.ViewModels
{
    public class MarketDataViewModel
    {
        public GlobalMarketDataViewModel? GlobalMarketData { get; set; }

        public List<ShortCoinViewModel>? TopCoins { get; set; }

        public List<ShortCoinViewModel>? RecommendedCoins { get; set; }
    }
}
