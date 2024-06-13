using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.LanguageFramework.Vocabularies
{
    public class EnglishVocabulary : IVocabulary
    {
        public Language Language { get; } = Language.English;

        public Dictionary<LabelType, string> Labels { get; } = new Dictionary<LabelType, string>
        {
            { LabelType.ChangeAppThemeLabel, "Dark Mode" },
            { LabelType.ChangeAppLanguageLabel, "Language" },

            { LabelType.BackButtonLabel, "Back" },
            { LabelType.ClearButtonLabel, "Clear" },

            { LabelType.SearchCoinLabel, "Search Coin" },
            { LabelType.NoDataLabel, "No data" },

            { LabelType.SearchButtonLabel, "Search" },
            { LabelType.TypeCoinNameLabel, "Type coin name..." },

            { LabelType.CoinSymbolLabel, "Symbol" },
            { LabelType.CoinNameLabel, "Name" },
            { LabelType.CoinPriceLabel, "Price" },
            { LabelType.CoinMarketCapLabel, "Market Cap" },
            { LabelType.CoinTotalVolumeLabel, "Volume" },
            { LabelType.CoinHigh24hLabel, "Highest price in 24h" },
            { LabelType.CoinLow24hLabel, "Lowest price in 24h" },
            { LabelType.CoinPriceChange24hLabel, "Price change per 24h" },
            { LabelType.CoinPriceChangePercentage24hLabel, "Percentage price change per 24h" },
            { LabelType.CoinMarketCapRankLabel, "Market Cap Rank" },

            { LabelType.InputAmountLabel, "Input amount..." },
            { LabelType.OutputAmountLabel, "Output amount..." },
            { LabelType.InputCurrencyLabel, "Input currency..." },
            { LabelType.OutputCurrencyLabel, "Output currency..."},

            { LabelType.ConvertButtonLabel, "Convert" }
        };

        public Dictionary<string, string> Pages { get; } = new Dictionary<string, string>
        {
            { "Main Menu", "Main Menu" },
            { "Analytics", "Analytics" },
            { "Coin Search", "Coin Search" },
            { "Converter", "Converter" },
            { "News", "News" },
            { "Predictions", "Predictions" },
            { "Settings", "Settings" },
        };
    }
}
