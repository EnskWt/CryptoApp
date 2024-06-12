using CryptoApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.ViewModels
{
    public class ShortCoinViewModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
    
    public static class ShortCoinViewModelExtensions
    {
        public static ShortCoinViewModel ToShortCoin(this Coin coin)
        {
            return new ShortCoinViewModel
            {
                Id = coin.Id,
                Name = coin.Name
            };
        }
    }
}
