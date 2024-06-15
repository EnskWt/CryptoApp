using CryptoApp.Services.ViewModels;
using CryptoApp.Shared.LanguageStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.Services.NewsService
{
    public interface INewsService
    {
        Task<List<NewsContentViewModel>> GetAllNews(Language language);
    }
}
