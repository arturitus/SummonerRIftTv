using System.Globalization;

namespace LeagueSpectator.MVVM.IServices
{
    public interface ILocalizationStringsService
    {
        public string Spectate { get; }
        public string SearchSummoner { get; }
        public string SummonerName { get; }
        public string Search { get; }
        public string Region { get; }
        public string Options { get; }
        public string LolFolder { get; }
        public string RiotApiKey { get; }
        public string Theme { get; }
        public string Language { get; }
        public string Runes { get; }
        public string RedTeam { get; }
        public string BlueTeam { get; }
        public string Bans { get; }

        public void SetCultureInfo(CultureInfo culture);
        public CultureInfo GetCultureInfo();
    }
}
