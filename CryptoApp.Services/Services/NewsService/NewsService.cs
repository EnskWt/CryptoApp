using CryptoApp.Services.Models;
using CryptoApp.Services.ViewModels;
using CryptoApp.Shared.LanguageStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.Services.NewsService
{
    public class NewsService : INewsService
    {
        private readonly NewsRepository _newsRepository;

        public NewsService()
        {
            _newsRepository = new NewsRepository();
        }

        public async Task<List<NewsContentViewModel>> GetAllNews(Language language)
        {
            var news = await _newsRepository.GetAllNewsAsync();

            if (news == null)
            {
                return new List<NewsContentViewModel>();
            }

            return news.Select(n => n.ToNewsContent(language)).ToList();
        }
    }

    #region NewsRepository - Not implemented/Mock
    // This is a placeholder for the repository that would be used to fetch the news from the database,
    // but it is not implemented in this project due to reason, that it is not the main focus of this project.
    public class NewsRepository
    {
        public async Task<List<News>?> GetAllNewsAsync()
        {
            var news = new News
            {
                Title = new Dictionary<Language, string>
                {
                    { Language.English, "Release!" },
                    { Language.Polish, "Release!" },
                    { Language.Ukranian, "Реліз!" }
                    
                },
                Description = new Dictionary<Language, string>
                {
                    { Language.English, "Dear friends, our application is released! Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce a purus at libero fringilla ultrices sit amet eget orci. Nullam feugiat dolor et orci eleifend, vitae cursus nisi sodales. Proin malesuada turpis nec porta volutpat. Aenean arcu urna, lobortis at pharetra eu, commodo quis ex. Nam sed tellus erat. Maecenas nisl nisl, posuere eu neque at, vehicula blandit enim. Curabitur consectetur sem nibh, vel mollis turpis efficitur non. Sed ac lacus egestas, pulvinar nisl quis, facilisis neque. Duis eu dolor a sapien vulputate maximus. Phasellus bibendum et enim id pretium. Maecenas et urna ut diam porta elementum." },
                    { Language.Polish, "Drodzy przyjaciele, nasza aplikacja została wydana! Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce a purus at libero fringilla ultrices sit amet eget orci. Nullam feugiat dolor et orci eleifend, vitae cursus nisi sodales. Proin malesuada turpis nec porta volutpat. Aenean arcu urna, lobortis at pharetra eu, commodo quis ex. Nam sed tellus erat. Maecenas nisl nisl, posuere eu neque at, vehicula blandit enim. Curabitur consectetur sem nibh, vel mollis turpis efficitur non. Sed ac lacus egestas, pulvinar nisl quis, facilisis neque. Duis eu dolor a sapien vulputate maximus. Phasellus bibendum et enim id pretium. Maecenas et urna ut diam porta elementum." },
                    { Language.Ukranian, "Дорогі друзі, наш додаток випущено! Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce a purus at libero fringilla ultrices sit amet eget orci. Nullam feugiat dolor et orci eleifend, vitae cursus nisi sodales. Proin malesuada turpis nec porta volutpat. Aenean arcu urna, lobortis at pharetra eu, commodo quis ex. Nam sed tellus erat. Maecenas nisl nisl, posuere eu neque at, vehicula blandit enim. Curabitur consectetur sem nibh, vel mollis turpis efficitur non. Sed ac lacus egestas, pulvinar nisl quis, facilisis neque. Duis eu dolor a sapien vulputate maximus. Phasellus bibendum et enim id pretium. Maecenas et urna ut diam porta elementum." }
                }
            };

            return await Task.FromResult(new List<News> { news });
        }
    }
    #endregion
}
