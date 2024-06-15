using CryptoApp.Services.Models;
using CryptoApp.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.Services.CoinSearchService
{
    public interface ICoinSearchService
    {
        Task<List<ShortCoinViewModel>> GetInitialCoinsForSearchCoinsPicker();

        Task<List<ShortCoinViewModel>> GetCoinsForSearchCoinsPicker(string searchQuery);

        Task<CoinInfoViewModel> GetCoinInfo(string coinId);
    }
}
