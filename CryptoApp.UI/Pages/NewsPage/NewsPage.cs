using CryptoApp.Services.Services.NewsService;
using CryptoApp.UI.Attributes;
using CryptoApp.UI.Pages.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.Pages.NewsPage
{
    [PageTitle("News")]
    public partial class NewsPage : ApplicationPage
    {
        private readonly INewsService _newsService;

        public NewsPage(INewsService newsService) : base()
        {
            _newsService = newsService;
        }

        protected override async Task<Layout> BuildPageLayout()
        {
            var appLayout = await base.BuildPageLayout();

            var newsBoxes = await GetNewsSection();

            appLayout.Children.Add(newsBoxes);

            return appLayout;
        }
    }
}
