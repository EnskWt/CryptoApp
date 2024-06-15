using CryptoApp.Shared.LanguageStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.LanguageFramework.Vocabularies
{
    public class UkranianVocabulary : IVocabulary
    {
        public Language Language { get; } = Language.Polish;

        public Dictionary<LabelType, string> Labels { get; } = new Dictionary<LabelType, string>
        {
            { LabelType.ChangeAppThemeLabel, "Темний режим" },
            { LabelType.ChangeAppLanguageLabel, "Мова" },

            { LabelType.BackButtonLabel, "Назад" },
            { LabelType.ClearButtonLabel, "Очистити" },

            { LabelType.SearchCoinLabel, "Пошук монети" },
            { LabelType.NoDataLabel, "Немає даних" },

            { LabelType.SearchButtonLabel, "Пошук" },
            { LabelType.TypeCoinNameLabel, "Введіть назву монети..." },

            { LabelType.CoinSymbolLabel, "Символ" },
            { LabelType.CoinNameLabel, "Назва" },
            { LabelType.CoinPriceLabel, "Ціна" },
            { LabelType.CoinMarketCapLabel, "Ринкова капіталізація" },
            { LabelType.CoinTotalVolumeLabel, "Обсяг" },
            { LabelType.CoinHigh24hLabel, "Найвища ціна за 24 години" },
            { LabelType.CoinLow24hLabel, "Найнижча ціна за 24 години" },
            { LabelType.CoinPriceChange24hLabel, "Зміна ціни за 24 години" },
            { LabelType.CoinPriceChangePercentage24hLabel, "Відсоткова зміна ціни за 24 години" },
            { LabelType.CoinMarketCapRankLabel, "Рейтинг ринкової капіталізації" },

            { LabelType.InputAmountLabel, "Введіть суму..." },
            { LabelType.OutputAmountLabel, "Вихідна сума..." },
            { LabelType.InputCurrencyLabel, "Вхідна валюта..." },
            { LabelType.OutputCurrencyLabel, "Вихідна валюта..."},

            { LabelType.ConvertButtonLabel, "Конвертувати" },

            { LabelType.GlobalMarketDataLabel, "Глобальні ринкові дані" },
            { LabelType.ActiveCryptocurrenciesCountLabel, "Активні криптовалюти" },
            { LabelType.MarketsCountLabel, "Ринки" },
            { LabelType.MarketCapChangePercentageLabel, "Зміна ринкової капіталізації (24г)" },
            { LabelType.UpcomingIcosCountLabel, "Майбутні ICO" },
            { LabelType.OngoingIcosCountLabel, "Поточні ICO" },
            { LabelType.EndedIcosCountLabel, "Завершені ICO" },
            { LabelType.TotalVolumeLabel, "Загальний обсяг (24г)" },
            { LabelType.TopCoinsLabel, "Топ 10 монет" },
            { LabelType.RecommendedCoinsLabel, "Рекомендовані монети" },

            { LabelType.PricesChartLabel, "Графіки цін" },
            { LabelType.MarketCapsChartLabel, "Графіки ринкової капіталізації" },
            { LabelType.TotalVolumesChartLabel, "Графіки обсягів" },

            { LabelType.ChartTimeAxisLabel, "Час" },
            { LabelType.ChartPriceAxisLabel, "Ціна" },
        };

        public Dictionary<string, string> Pages { get; } = new Dictionary<string, string>
        {
            { "Main Menu", "Головне меню" },
            { "Analytics", "Аналітика" },
            { "Coin Search", "Пошук монет" },
            { "Converter", "Конвертер" },
            { "News", "Новини" },
            { "Predictions", "Прогнози" },
            { "Settings", "Налаштування" },
        };
    }
}
