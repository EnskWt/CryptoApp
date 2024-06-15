using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.ViewModels
{
    public class MarketChartDataViewData
    {
        public string? CoinName { get; set; }
        public List<List<double>>? Prices { get; set; }
        public List<List<double>>? MarketCaps { get; set; }
        public List<List<double>>? TotalVolumes { get; set; }
    }
}
