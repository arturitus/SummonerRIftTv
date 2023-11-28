using LeagueSpectator.MVVM.Extensions;
using LeagueSpectator.MVVM.IServices;
using LeagueSpectator.MVVM.Models;
using ReactiveUI;
using System.Globalization;
using System.Reflection;

namespace LeagueSpectator.MVVM.Services
{
    public class LocalizationStringsService : ReactiveObject, ILocalizationStringsService
    {
        [LocalizationField("en-EN", "Spectate")]
        [LocalizationField("es-ES", "Espectar")]
        public string Spectate => this.GetDisplayName(nameof(Spectate));

        [LocalizationField("en-EN", "Search for a Summoner")]
        [LocalizationField("es-ES", "Buscar a un Invocador")]
        public string SearchSummoner => this.GetDisplayName(nameof(SearchSummoner));

        [LocalizationField("en-EN", "Summoner name")]
        [LocalizationField("es-ES", "Nombre de invocador")]
        public string SummonerName => this.GetDisplayName(nameof(SummonerName));

        [LocalizationField("en-EN", "Search")]
        [LocalizationField("es-ES", "Buscar")]
        public string Search => this.GetDisplayName(nameof(Search));

        [LocalizationField("en-EN", "Region")]
        [LocalizationField("es-ES", "Región")]
        public string Region => this.GetDisplayName(nameof(Region));

        [LocalizationField("en-EN", "Options")]
        [LocalizationField("es-ES", "Opciones")]
        public string Options => this.GetDisplayName(nameof(Options));

        [LocalizationField("en-EN", "League of Legends folder path")]
        [LocalizationField("es-ES", "Carpeta de League of Legends")]
        public string LolFolder => this.GetDisplayName(nameof(LolFolder));

        [LocalizationField("en-EN", "Riot API key")]
        [LocalizationField("es-ES", "Clave de la API de Riot")]
        public string RiotApiKey => this.GetDisplayName(nameof(RiotApiKey));

        [LocalizationField("en-EN", "Theme")]
        [LocalizationField("es-ES", "Tema")]
        public string Theme => this.GetDisplayName(nameof(Theme));
        [LocalizationField("en-EN", "Language")]
        [LocalizationField("es-ES", "Idioma")]
        public string Language => this.GetDisplayName(nameof(Language));

        [LocalizationField("en-EN", "Runes")]
        [LocalizationField("es-ES", "Runas")]
        public string Runes => this.GetDisplayName(nameof(Runes));

        [LocalizationField("en-EN", "Red Team")]
        [LocalizationField("es-ES", "Equipo Rojo")]
        public string RedTeam => this.GetDisplayName(nameof(RedTeam));

        [LocalizationField("en-EN", "Blue Team")]
        [LocalizationField("es-ES", "Equipo Azul")]
        public string BlueTeam => this.GetDisplayName(nameof(BlueTeam));

        [LocalizationField("en-EN", "Bans")]
        [LocalizationField("es-ES", "Bloqueos")]
        public string Bans => this.GetDisplayName(nameof(Bans));

        public void SetCultureInfo(CultureInfo culture)
        {
            CultureInfo.CurrentCulture = culture;
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                this.RaisePropertyChanged(property.Name);
            }
        }
    }
}
