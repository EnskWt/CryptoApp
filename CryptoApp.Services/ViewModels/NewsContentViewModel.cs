using CryptoApp.Services.Models;
using CryptoApp.Shared.LanguageStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.ViewModels
{
    public class NewsContentViewModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
    }

    public static class NewsContentViewModelExtensions
    {
        public static NewsContentViewModel ToNewsContent(this News news, Language language)
        {
            return new NewsContentViewModel
            {
                Title = news.Title?.GetValueOrDefault(language) ?? news.Title?.GetValueOrDefault(Language.English),
                Description = news.Description?.GetValueOrDefault(language) ?? news.Description?.GetValueOrDefault(Language.English)
            };
        }
    }
}
