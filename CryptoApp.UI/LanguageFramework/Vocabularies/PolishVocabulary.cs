using CryptoApp.Shared.LanguageStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.UI.LanguageFramework.Vocabularies
{
    public class PolishVocabulary : IVocabulary
    {
        public Language Language { get; } = Language.Polish;

        public Dictionary<LabelType, string> Labels { get; } = new Dictionary<LabelType, string>
        {
            { LabelType.ChangeAppThemeLabel, "Tryb ciemny" },
            { LabelType.ChangeAppLanguageLabel, "Język" },

            { LabelType.BackButtonLabel, "Wstecz" },
            { LabelType.ClearButtonLabel, "Wyczyść" },

            { LabelType.SearchCoinLabel, "Wyszukaj monetę" },
            { LabelType.NoDataLabel, "Brak danych" },

            { LabelType.SearchButtonLabel, "Szukaj" },
            { LabelType.TypeCoinNameLabel, "Wpisz nazwę monety..." },

            { LabelType.CoinSymbolLabel, "Symbol" },
            { LabelType.CoinNameLabel, "Nazwa" },
            { LabelType.CoinPriceLabel, "Cena" },
            { LabelType.CoinMarketCapLabel, "Kapitalizacja rynkowa" },
            { LabelType.CoinTotalVolumeLabel, "Wolumen" },
            { LabelType.CoinHigh24hLabel, "Najwyższa cena za 24 godziny" },
            { LabelType.CoinLow24hLabel, "Najniższa cena za 24 godziny" },
            { LabelType.CoinPriceChange24hLabel, "Zmiana ceny za 24 godziny" },
            { LabelType.CoinPriceChangePercentage24hLabel, "Procentowa zmiana ceny za 24h" },
            { LabelType.CoinMarketCapRankLabel, "Ranking kapitalizacji rynkowej" },

            { LabelType.InputAmountLabel, "Wpisz kwotę..." },
            { LabelType.OutputAmountLabel, "Kwota wyjściowa..." },
            { LabelType.InputCurrencyLabel, "Waluta wejściowa..." },
            { LabelType.OutputCurrencyLabel, "Waluta wyjściowa..." },
            
            { LabelType.ConvertButtonLabel, "Konwertuj" },

            { LabelType.GlobalMarketDataLabel, "Dane rynkowe globalne" },
            { LabelType.ActiveCryptocurrenciesCountLabel, "Aktywne kryptowaluty" },
            { LabelType.MarketsCountLabel, "Rynki" },
            { LabelType.MarketCapChangePercentageLabel, "Zmiana kapitalizacji rynkowej (24h)" },
            { LabelType.UpcomingIcosCountLabel, "Nadchodzące ICO" },
            { LabelType.OngoingIcosCountLabel, "Trwające ICO" },
            { LabelType.EndedIcosCountLabel, "Zakończone ICO" },
            { LabelType.TotalVolumeLabel, "Całkowity wolumen (24h)" },
            { LabelType.TopCoinsLabel, "Top 10 monet" },
            { LabelType.RecommendedCoinsLabel, "Zalecane monety" },

            { LabelType.PricesChartLabel, "Wykresy cen" },
            { LabelType.MarketCapsChartLabel, "Wykresy kapitalizacji rynkowej" },
            { LabelType.TotalVolumesChartLabel, "Wykresy wolumenów" },

            { LabelType.ChartTimeAxisLabel, "Czas" },
            { LabelType.ChartPriceAxisLabel, "Cena" },
        };

        public Dictionary<string, string> Pages { get; } = new Dictionary<string, string>
        {
            { "Main Menu", "Menu główne" },
            { "Analytics", "Analityka" },
            { "Coin Search", "Wyszukiwanie" },
            { "Converter", "Konwerter" },
            { "News", "Aktualności" },
            { "Predictions", "Przewidywania" },
            { "Settings", "Ustawienia" },
        };
    }
}
