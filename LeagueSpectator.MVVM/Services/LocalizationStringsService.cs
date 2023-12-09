using LeagueSpectator.MVVM.IServices;
using LeagueSpectator.MVVM.Models;
using LeagueSpectator.RiotApi.Models;
using ReactiveUI;
using System.Collections.Frozen;
using System.Globalization;

namespace LeagueSpectator.MVVM.Services
{
    public class LocalizationStringsService : ReactiveObject, ILocalizationStringsService
    {
        public string Spectate => m_Strings[nameof(Spectate)];
        public string SearchSummoner => m_Strings[nameof(SearchSummoner)];
        public string SummonerName => m_Strings[nameof(SummonerName)];
        public string Search => m_Strings[nameof(Search)];
        public string Region => m_Strings[nameof(Region)];
        public string Options => m_Strings[nameof(Options)];
        public string LolFolder => m_Strings[nameof(LolFolder)];
        public string RiotApiKey => m_Strings[nameof(RiotApiKey)];
        public string Theme => m_Strings[nameof(Theme)];
        public string Language => m_Strings[nameof(Language)];
        public string Runes => m_Strings[nameof(Runes)];
        public string RedTeam => m_Strings[nameof(RedTeam)];
        public string BlueTeam => m_Strings[nameof(BlueTeam)];
        public string Bans => m_Strings[nameof(Bans)];

        public void SetCultureInfo(CultureInfo culture)
        {
            CultureInfo.CurrentCulture = culture;
            //PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //foreach (PropertyInfo property in properties)
            //{
            //    this.RaisePropertyChanged(property.Name);
            //}

            foreach (KeyValuePair<string, LocalizableString> keyValue in m_Strings)
            {
                this.RaisePropertyChanged(keyValue.Key);
            }
        }

        private readonly FrozenDictionary<string, LocalizableString> m_Strings = new Dictionary<string, LocalizableString>()
        {
            {
                nameof(Spectate), new LocalizableString
                ([
                    new LanguageObject("en-EN", "Spectate"),
                    new LanguageObject("es-ES", "Espectar")
                ])
            },
            {
                nameof(SearchSummoner), new LocalizableString
                ([
                    new LanguageObject("en-EN", "Search for a Summoner"),
                    new LanguageObject("es-ES", "Buscar a un Invocador")
                ])
            },
            {
                nameof(SummonerName), new LocalizableString
                ([
                    new LanguageObject("en-EN", "Summoner name"),
                    new LanguageObject("es-ES", "Nombre de invocador")
                ])
            },
            {
                nameof(Search), new LocalizableString
                ([
                    new LanguageObject("en-EN", "Search"),
                    new LanguageObject("es-ES", "Buscar")
                ])
            },
            {
                nameof(Region), new LocalizableString
                ([
                    new LanguageObject("en-EN", "Region"),
                    new LanguageObject("es-ES", "Región")
                ])
            },
            {
                nameof(Options), new LocalizableString
                ([
                    new LanguageObject("en-EN", "Options"),
                    new LanguageObject("es-ES", "Opciones")
                ])
            },
            {
                nameof(LolFolder), new LocalizableString
                ([
                    new LanguageObject("en-EN", "League of Legends folder path"),
                    new LanguageObject("es-ES", "Carpeta de League of Legends")
                ])
            },
            {
                nameof(RiotApiKey), new LocalizableString
                ([
                    new LanguageObject("en-EN", "Riot API key"),
                    new LanguageObject("es-ES", "Clave de la API de Riot")
                ])
            },
            {
                nameof(Theme), new LocalizableString
                ([
                    new LanguageObject("en-EN", "Theme"),
                    new LanguageObject("es-ES", "Tema")
                ])
            },
            {
                nameof(Language), new LocalizableString
                ([
                    new LanguageObject("en-EN", "Language "),
                    new LanguageObject("es-ES", "Idioma")
                ])
            },
            {
                nameof(Runes), new LocalizableString
                ([
                    new LanguageObject("en-EN", "Runes"),
                    new LanguageObject("es-ES", "Runas")
                ])
            },
            {
                nameof(RedTeam), new LocalizableString
                ([
                    new LanguageObject("en-EN", "Red Team"),
                    new LanguageObject("es-ES", "Equipo Rojo")
                ])
            },
            {
                nameof(BlueTeam), new LocalizableString
                ([
                    new LanguageObject("en-EN", "Blue Team"),
                    new LanguageObject("es-ES", "Equipo Azul")
                ])
            },
            {
                nameof(Bans), new LocalizableString
                ([
                    new LanguageObject("en-EN", "Bans"),
                    new LanguageObject("es-ES", "Bans")
                ])
            }

        }.ToFrozenDictionary();
    }
    public readonly struct LocalizableString
    {
        private readonly FrozenSet<LanguageObject> m_Languages;

        public LocalizableString(LanguageObject[] languages)
        {
            m_Languages = languages.ToFrozenSet();
        }

        public override string ToString()
        {
            return m_Languages.FirstOrDefault(x => x.CultureInfo.Name == CultureInfo.CurrentCulture.Name).DisplayName;
        }

        public static implicit operator string(LocalizableString localizableString)
        {
            return localizableString.ToString();
        }
    }

    public readonly struct LanguageObject
    {
        public CultureInfo CultureInfo { get; }
        public string DisplayName { get; }

        public LanguageObject(string cultureInfo, string displayName) : this()
        {
            CultureInfo = new CultureInfo(cultureInfo);
            DisplayName = displayName;
        }
    }

    public readonly struct LocalizableEnum<T>
    {
        public T EnumValue { get; }
        public LocalizableString DisplayName { get; }

        public LocalizableEnum(T enumValue, LocalizableString displayName)
        {
            EnumValue = enumValue;
            DisplayName = displayName;
        }
    }

    public static class LocalizableEnumCollection
    {
        public static readonly FrozenSet<LocalizableEnum<ChampionType>> championCollection = new LocalizableEnum<ChampionType>[]
        {
            new LocalizableEnum<ChampionType>(ChampionType.None,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "None"),
                    new LanguageObject("es-ES", "Ninguno")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Annie,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Annie"),
                    new LanguageObject("es-ES", "Annie")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Kayle,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Kayle"),
                    new LanguageObject("es-ES", "Kayle")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Xerath,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Xerath"),
                    new LanguageObject("es-ES", "Xerath")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Shyvana,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Shyvana"),
                    new LanguageObject("es-ES", "Shyvana")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Ahri,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Ahri"),
                    new LanguageObject("es-ES", "Ahri")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Graves,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Graves"),
                    new LanguageObject("es-ES", "Graves")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Fizz,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Fizz"),
                    new LanguageObject("es-ES", "Fizz")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Volibear,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Volibear"),
                    new LanguageObject("es-ES", "Volibear")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Rengar,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Rengar"),
                    new LanguageObject("es-ES", "Rengar")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.MasterYi,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Master Yi"),
                    new LanguageObject("es-ES", "Maestro Yi")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Varus,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Varus"),
                    new LanguageObject("es-ES", "Varus")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Nautilus,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Nautilus"),
                    new LanguageObject("es-ES", "Nautilus")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Viktor,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Viktor"),
                    new LanguageObject("es-ES", "Viktor")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Sejuani,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Sejuani"),
                    new LanguageObject("es-ES", "Sejuani")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Fiora,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Fiora"),
                    new LanguageObject("es-ES", "Fiora")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Ziggs,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Ziggs"),
                    new LanguageObject("es-ES", "Ziggs")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Lulu,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Lulu"),
                    new LanguageObject("es-ES", "Lulu")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Draven,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Draven"),
                    new LanguageObject("es-ES", "Draven")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Alistar,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Alistar"),
                    new LanguageObject("es-ES", "Alistar")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Hecarim,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Hecarim"),
                    new LanguageObject("es-ES", "Hecarim")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.KhaZix,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Kha'Zix"),
                    new LanguageObject("es-ES", "Kha'Zix")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Darius,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Darius"),
                    new LanguageObject("es-ES", "Darius")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Jayce,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Jayce"),
                    new LanguageObject("es-ES", "Jayce")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Lissandra,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Lissandra"),
                    new LanguageObject("es-ES", "Lissandra")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Ryze,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Ryze"),
                    new LanguageObject("es-ES", "Ryze")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Diana,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Diana"),
                    new LanguageObject("es-ES", "Diana")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Quinn,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Quinn"),
                    new LanguageObject("es-ES", "Quinn")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Syndra,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Syndra"),
                    new LanguageObject("es-ES", "Syndra")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.AurelionSol,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Aurelion Sol"),
                    new LanguageObject("es-ES", "Aurelion Sol")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Sion,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Sion"),
                    new LanguageObject("es-ES", "Sion")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Kayn,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Kayn"),
                    new LanguageObject("es-ES", "Kayn")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Zoe,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Zoe"),
                    new LanguageObject("es-ES", "Zoe")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Zyra,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Zyra"),
                    new LanguageObject("es-ES", "Zyra")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Kaisa,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Kai'Sa"),
                    new LanguageObject("es-ES", "Kai'Sa")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Seraphine,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Seraphine"),
                    new LanguageObject("es-ES", "Seraphine")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Sivir,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Sivir"),
                    new LanguageObject("es-ES", "Sivir")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Gnar,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Gnar"),
                    new LanguageObject("es-ES", "Gnar")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Zac,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Zac"),
                    new LanguageObject("es-ES", "Zac")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Yasuo,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Yasuo"),
                    new LanguageObject("es-ES", "Yasuo")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Soraka,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Soraka"),
                    new LanguageObject("es-ES", "Soraka")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Velkoz,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Vel'Koz"),
                    new LanguageObject("es-ES", "Vel'Koz")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Taliyah,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Taliyah"),
                    new LanguageObject("es-ES", "Taliyah")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Camille,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Camille"),
                    new LanguageObject("es-ES", "Camille")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Akshan,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Akshan"),
                    new LanguageObject("es-ES", "Akshan")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Teemo,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Teemo"),
                    new LanguageObject("es-ES", "Teemo")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Tristana,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Tristana"),
                    new LanguageObject("es-ES", "Tristana")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Warwick,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Warwick"),
                    new LanguageObject("es-ES", "Warwick")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Olaf,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Olaf"),
                    new LanguageObject("es-ES", "Olaf")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Nunu,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Nunu"),
                    new LanguageObject("es-ES", "Nunu")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Belveth,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Bel'Veth"),
                    new LanguageObject("es-ES", "Bel'Veth")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Braum,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Braum"),
                    new LanguageObject("es-ES", "Braum")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Jhin,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Jhin"),
                    new LanguageObject("es-ES", "Jhin")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Kindred,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Kindred"),
                    new LanguageObject("es-ES", "Kindred")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.MissFortune,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Miss Fortune"),
                    new LanguageObject("es-ES", "Miss Fortune")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Ashe,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Ashe"),
                    new LanguageObject("es-ES", "Ashe")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Zeri,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Zeri"),
                    new LanguageObject("es-ES", "Zeri")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Jinx,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Jinx"),
                    new LanguageObject("es-ES", "Jinx")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.TahmKench,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Tahm Kench"),
                    new LanguageObject("es-ES", "Tahm Kench")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Tryndamere,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Tryndamere"),
                    new LanguageObject("es-ES", "Tryndamere")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Briar,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Briar"),
                    new LanguageObject("es-ES", "Briar")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Viego,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Viego"),
                    new LanguageObject("es-ES", "Viego")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Senna,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Senna"),
                    new LanguageObject("es-ES", "Senna")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Lucian,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Lucian"),
                    new LanguageObject("es-ES", "Lucian")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Zed,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Zed"),
                    new LanguageObject("es-ES", "Zed")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Jax,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Jax"),
                    new LanguageObject("es-ES", "Jax")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Kled,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Kled"),
                    new LanguageObject("es-ES", "Kled")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Ekko,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Ekko"),
                    new LanguageObject("es-ES", "Ekko")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Qiyana,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Qiyana"),
                    new LanguageObject("es-ES", "Qiyana")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Morgana,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Morgana"),
                    new LanguageObject("es-ES", "Morgana")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Vi,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Vi"),
                    new LanguageObject("es-ES", "Vi")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Zilean,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Zilean"),
                    new LanguageObject("es-ES", "Zilean")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Aatrox,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Aatrox"),
                    new LanguageObject("es-ES", "Aatrox")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Nami,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Nami"),
                    new LanguageObject("es-ES", "Nami")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Azir,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Azir"),
                    new LanguageObject("es-ES", "Azir")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Singed,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Singed"),
                    new LanguageObject("es-ES", "Singed")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Evelynn,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Evelynn"),
                    new LanguageObject("es-ES", "Evelynn")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Twitch,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Twitch"),
                    new LanguageObject("es-ES", "Twitch")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Galio,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Galio"),
                    new LanguageObject("es-ES", "Galio")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Karthus,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Karthus"),
                    new LanguageObject("es-ES", "Karthus")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.ChoGath,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Cho'Gath"),
                    new LanguageObject("es-ES", "Cho'Gath")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Amumu,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Amumu"),
                    new LanguageObject("es-ES", "Amumu")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Rammus,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Rammus"),
                    new LanguageObject("es-ES", "Rammus")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Anivia,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Anivia"),
                    new LanguageObject("es-ES", "Anivia")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Shaco,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Shaco"),
                    new LanguageObject("es-ES", "Shaco")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Yuumi,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Yuumi"),
                    new LanguageObject("es-ES", "Yuumi")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.DrMundo,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Dr. Mundo"),
                    new LanguageObject("es-ES", "Dr. Mundo")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Samira,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Samira"),
                    new LanguageObject("es-ES", "Samira")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Sona,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Sona"),
                    new LanguageObject("es-ES", "Sona")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Kassadin,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Kassadin"),
                    new LanguageObject("es-ES", "Kassadin")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Irelia,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Irelia"),
                    new LanguageObject("es-ES", "Irelia")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.TwistedFate,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Twisted Fate"),
                    new LanguageObject("es-ES", "Twisted Fate")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Janna,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Janna"),
                    new LanguageObject("es-ES", "Janna")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Gangplank,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Gangplank"),
                    new LanguageObject("es-ES", "Gangplank")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Thresh,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Thresh"),
                    new LanguageObject("es-ES", "Thresh")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Corki,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Corki"),
                    new LanguageObject("es-ES", "Corki")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Illaoi,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Illaoi"),
                    new LanguageObject("es-ES", "Illaoi")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.RekSai,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Rek'Sai"),
                    new LanguageObject("es-ES", "Rek'Sai")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Ivern,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Ivern"),
                    new LanguageObject("es-ES", "Ivern")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Kalista,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Kalista"),
                    new LanguageObject("es-ES", "Kalista")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Karma,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Karma"),
                    new LanguageObject("es-ES", "Karma")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Bard,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Bard"),
                    new LanguageObject("es-ES", "Bardo")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Taric,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Taric"),
                    new LanguageObject("es-ES", "Taric")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Veigar,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Veigar"),
                    new LanguageObject("es-ES", "Veigar")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Trundle,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Trundle"),
                    new LanguageObject("es-ES", "Trundle")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Rakan,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Rakan"),
                    new LanguageObject("es-ES", "Rakan")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Xayah,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Xayah"),
                    new LanguageObject("es-ES", "Xayah")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.XinZhao,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "XinZhao"),
                    new LanguageObject("es-ES", "XinZhao")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Swain,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Swain"),
                    new LanguageObject("es-ES", "Swain")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Caitlyn,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Caitlyn"),
                    new LanguageObject("es-ES", "Caitlyn")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Ornn,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Ornn"),
                    new LanguageObject("es-ES", "Ornn")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Sylas,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Sylas"),
                    new LanguageObject("es-ES", "Sylas")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Neeko,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Neeko"),
                    new LanguageObject("es-ES", "Neeko")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Aphelios,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Aphelios"),
                    new LanguageObject("es-ES", "Aphelios")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Rell,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Rell"),
                    new LanguageObject("es-ES", "Rell")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Blitzcrank,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Blitzcrank"),
                    new LanguageObject("es-ES", "Blitzcrank")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Malphite,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Malphite"),
                    new LanguageObject("es-ES", "Malphite")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Katarina,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Katarina"),
                    new LanguageObject("es-ES", "Katarina")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Pyke,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Pyke"),
                    new LanguageObject("es-ES", "Pyke")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Nocturne,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Nocturne"),
                    new LanguageObject("es-ES", "Nocturne")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Maokai,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Maokai"),
                    new LanguageObject("es-ES", "Maokai")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Renekton,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Renekton"),
                    new LanguageObject("es-ES", "Renekton")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.JarvanIV,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Jarvan IV"),
                    new LanguageObject("es-ES", "Jarvan IV")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Urgot,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Urgot"),
                    new LanguageObject("es-ES", "Urgot")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Elise,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Elise"),
                    new LanguageObject("es-ES", "Elise")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Orianna,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Orianna"),
                    new LanguageObject("es-ES", "Orianna")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Wukong,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Wukong"),
                    new LanguageObject("es-ES", "Wukong")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Brand,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Brand"),
                    new LanguageObject("es-ES", "Brand")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.LeeSin,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "LeeSin"),
                    new LanguageObject("es-ES", "LeeSin")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Vayne,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Vayne"),
                    new LanguageObject("es-ES", "Vayne")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Rumble,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Rumble"),
                    new LanguageObject("es-ES", "Rumble")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Cassiopeia,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Cassiopeia"),
                    new LanguageObject("es-ES", "Cassiopeia")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.LeBlanc,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "LeBlanc"),
                    new LanguageObject("es-ES", "LeBlanc")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Vex,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Vex"),
                    new LanguageObject("es-ES", "Vex")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Skarner,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Skarner"),
                    new LanguageObject("es-ES", "Skarner")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Heimerdinger,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Heimerdinger"),
                    new LanguageObject("es-ES", "Heimerdinger")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Nasus,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Nasus"),
                    new LanguageObject("es-ES", "Nasus")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Nidalee,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Nidalee"),
                    new LanguageObject("es-ES", "Nidalee")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Udyr,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Udyr"),
                    new LanguageObject("es-ES", "Udyr")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Yone,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Yone"),
                    new LanguageObject("es-ES", "Yone")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Poppy,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Poppy"),
                    new LanguageObject("es-ES", "Poppy")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Gragas,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Gragas"),
                    new LanguageObject("es-ES", "Gragas")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Vladirmir,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Vladirmir"),
                    new LanguageObject("es-ES", "Vladirmir")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Pantheon,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Pantheon"),
                    new LanguageObject("es-ES", "Pantheon")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Ezreal,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Ezreal"),
                    new LanguageObject("es-ES", "Ezreal")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Mordekaiser,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Mordekaiser"),
                    new LanguageObject("es-ES", "Mordekaiser")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Yorick,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Yorick"),
                    new LanguageObject("es-ES", "Yorick")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Akali,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Akali"),
                    new LanguageObject("es-ES", "Akali")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Kennen,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Kennen"),
                    new LanguageObject("es-ES", "Kennen")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Garen,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Garen"),
                    new LanguageObject("es-ES", "Garen")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Sett,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Sett"),
                    new LanguageObject("es-ES", "Sett")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Lillia,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Lillia"),
                    new LanguageObject("es-ES", "Lillia")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Gwen,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Gwen"),
                    new LanguageObject("es-ES", "Gwen")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.RenataGlasc,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Renata Glasc"),
                    new LanguageObject("es-ES", "Renata Glasc")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Leona,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Leona"),
                    new LanguageObject("es-ES", "Leona")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Nilah,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Nilah"),
                    new LanguageObject("es-ES", "Nilah")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Ksante,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "K'Sante"),
                    new LanguageObject("es-ES", "K'Sante")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Fiddlesticks,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Fiddlesticks"),
                    new LanguageObject("es-ES", "Fiddlesticks")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Malzahar,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Malzahar"),
                    new LanguageObject("es-ES", "Malzahar")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Talon,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Talon"),
                    new LanguageObject("es-ES", "Talon")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Hwei,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Hwei"),
                    new LanguageObject("es-ES", "Hwei")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Riven,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Riven"),
                    new LanguageObject("es-ES", "Riven")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Naafiri,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Naafiri"),
                    new LanguageObject("es-ES", "Naafiri")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.KogMaw,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Kog'Maw"),
                    new LanguageObject("es-ES", "Kog'Maw")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Shen,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Shen"),
                    new LanguageObject("es-ES", "Shen")
                ])
            ),
            new LocalizableEnum<ChampionType>(ChampionType.Lux,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Lux"),
                    new LanguageObject("es-ES", "Lux")
                ])
            )
        }.ToFrozenSet();

        public static readonly FrozenSet<LocalizableEnum<RuneType>> runeCollection = new List<LocalizableEnum<RuneType>>()
        {
            new LocalizableEnum<RuneType>(RuneType.HitPointsPerLevel,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Health per level"),
                    new LanguageObject("es-ES", "Vida por nivel")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Armor,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Armor"),
                    new LanguageObject("es-ES", "Armadura")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.MagicResist,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Magic resist"),
                    new LanguageObject("es-ES", "Resistencia mágica")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.AttackSpeed,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Attack speed"),
                    new LanguageObject("es-ES", "Velocidad de ataque")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.CooldownReductionPerLevel,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Cooldown reduction per level"),
                    new LanguageObject("es-ES", "Reducción de enfriamiento por nivel")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.AdaptativeForce,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Adaptative force"),
                    new LanguageObject("es-ES", "Fuerza adaptativa")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Precision,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Precision"),
                    new LanguageObject("es-ES", "Precisión")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.PressTheAttack,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Press the attack"),
                    new LanguageObject("es-ES", "Ataque intensificado")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.LethalTempo,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Lethal tempo"),
                    new LanguageObject("es-ES", "Compás letal")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.PressenceOfMind,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Pressence of mind"),
                    new LanguageObject("es-ES", "Claridad mental")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Conqueror,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Conqueror"),
                    new LanguageObject("es-ES", "Conquistador")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.CoupOfGrace,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Coup of grace"),
                    new LanguageObject("es-ES", "Golpe de gracia")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.CutDown,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Cut down"),
                    new LanguageObject("es-ES", "Derribado")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.FleetFootwork,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Fleet footwork"),
                    new LanguageObject("es-ES", "Pies veloces")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Domination,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Domination"),
                    new LanguageObject("es-ES", "Dominación")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.RelentlessHunter,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Relentless hunter"),
                    new LanguageObject("es-ES", "Cazador incensante")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.DefinitiveHunter,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Definitive hunter"),
                    new LanguageObject("es-ES", "Cazador definitivo")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Electrocute,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Electrocute"),
                    new LanguageObject("es-ES", "Electrocutar")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.PoroWard,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Poro ward"),
                    new LanguageObject("es-ES", "Poro fantasmal")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Predator,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Predator"),
                    new LanguageObject("es-ES", "Depredador")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.CheapShot,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Cheap shot"),
                    new LanguageObject("es-ES", "Golpe bajo")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.DarkHarvest,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Dark harvest"),
                    new LanguageObject("es-ES", "Cosecha oscura")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.IngeniousHunter,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Ingenious hunter"),
                    new LanguageObject("es-ES", "Cazador ingenioso")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.TreasureHunter,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Treasure hunter"),
                    new LanguageObject("es-ES", "Cazador de tesoros")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.ZombieWard,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Zombie ward"),
                    new LanguageObject("es-ES", "Guardián zombi")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.EyeballCollection,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Eyeball collection"),
                    new LanguageObject("es-ES", "Colección de globos oculares")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.TasteOfBlood,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Taste of blood"),
                    new LanguageObject("es-ES", "Sabor a sangre")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.SuddenImpact,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Sudden impact"),
                    new LanguageObject("es-ES", "Impacto repentino")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Sorcery,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Sorcery"),
                    new LanguageObject("es-ES", "Brujería")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Trascendence,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Trascendence"),
                    new LanguageObject("es-ES", "Trascendencia")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.SummonAery,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Summon Aery"),
                    new LanguageObject("es-ES", "Invocar a Aery")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.NullifyingOrb,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Nullifying orb"),
                    new LanguageObject("es-ES", "Orbe anulador")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.ManaflowBand,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Manaflow band"),
                    new LanguageObject("es-ES", "Banda de mána")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.ArcaneComet,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Arcane Comet"),
                    new LanguageObject("es-ES", "Cometa arcano")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.PhaseRush,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Phase rush"),
                    new LanguageObject("es-ES", "Irrupción de fase")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Waterwalking,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Water walking"),
                    new LanguageObject("es-ES", "Caminar sobre agua")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.AbsoluteFocus,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Absolute focus"),
                    new LanguageObject("es-ES", "Concentración absoluta")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Celerity,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Celerity"),
                    new LanguageObject("es-ES", "Celeridad")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.GatheringStorm,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Gathering storm"),
                    new LanguageObject("es-ES", "Se avecina tormenta")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Scorch,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Scorch"),
                    new LanguageObject("es-ES", "Piroláser")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Unflinching,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Unflinching"),
                    new LanguageObject("es-ES", "Inquebrantable")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.NimbusCloak,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Nimbus cloak"),
                    new LanguageObject("es-ES", "Capa del nimbo")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.LastStand,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Last stand"),
                    new LanguageObject("es-ES", "Último esfuerzo")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Inspiration,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Inspiration"),
                    new LanguageObject("es-ES", "Inspiración")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.MagicalFootwear,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Magical footwear"),
                    new LanguageObject("es-ES", "Calzado mágico")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.HextechFlashtraption,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Hextech flashtraption"),
                    new LanguageObject("es-ES", "Destello Hexflash")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.PerfectTiming,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Perfect timing"),
                    new LanguageObject("es-ES", "Momento oportuno")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.MinionDematerializer,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Minion dematerializer"),
                    new LanguageObject("es-ES", "Desmaterializador de súbditos")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.FuturesMarket,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Future's market"),
                    new LanguageObject("es-ES", "Mercado del futuro")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.BiscuitDelivery,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Biscuit delivery"),
                    new LanguageObject("es-ES", "Entrega de galletas")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.CosmicInsight,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Cosmic insight"),
                    new LanguageObject("es-ES", "Perspicacia cósmica")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.GlacialAugment,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Glacial augment"),
                    new LanguageObject("es-ES", "Aumento glacial")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.TimeWarpTonic,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Time warp tonic"),
                    new LanguageObject("es-ES", "Tónico de distorsion temporal")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.UnsealedSpellbook,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Unsealed spellbook"),
                    new LanguageObject("es-ES", "Libro de hechizos")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.FirstStrike,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "First strike"),
                    new LanguageObject("es-ES", "Primer golpe")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Resolve,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Resolve"),
                    new LanguageObject("es-ES", "Valor")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.ShieldBash,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Shield bash"),
                    new LanguageObject("es-ES", "Golpe de escudo")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.ApproachVelocity,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Approach velocity"),
                    new LanguageObject("es-ES", "Velocidad de acercamiento")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Conditioning,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Conditioning"),
                    new LanguageObject("es-ES", "Condicionamiento")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.GraspOfTheUndiying,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Grasp of the Undiying"),
                    new LanguageObject("es-ES", "Garras del inmortal")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Aftershock,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Aftershock"),
                    new LanguageObject("es-ES", "Reverberacción")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.SecondWind,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Second wind"),
                    new LanguageObject("es-ES", "Fuerzas renovadas")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Demolish,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Demolish"),
                    new LanguageObject("es-ES", "Demoler")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Overgrowth,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Overgrowth"),
                    new LanguageObject("es-ES", "Sobrecrecimiento")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Revitalize,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Revitalize"),
                    new LanguageObject("es-ES", "Revitalizar")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.FontOfLife,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Font of life"),
                    new LanguageObject("es-ES", "Fuente de vida")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Guardian,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Guardian"),
                    new LanguageObject("es-ES", "Protector")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.BonePlating,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Bone plating"),
                    new LanguageObject("es-ES", "Revestimiento de huesos")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Overheal,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Overheal"),
                    new LanguageObject("es-ES", "Supercuración")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.LegendBloodline,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Legend: Bloodline"),
                    new LanguageObject("es-ES", "Leyenda: Linaje")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.LegendAlacrity,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Legend: Alacrity"),
                    new LanguageObject("es-ES", "Leyenda: Presteza")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.LegendTenacity,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Legend: Tenacity"),
                    new LanguageObject("es-ES", "Leyenda: Tenacidad")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.Triumph,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Triumph"),
                    new LanguageObject("es-ES", "Triunfo")
                ])
            ),
            new LocalizableEnum<RuneType>(RuneType.HailOfBlades,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Hail of Blades"),
                    new LanguageObject("es-ES", "Lluvia de cuchillas")
                ])
            )
        }.ToFrozenSet();

        public static readonly FrozenSet<LocalizableEnum<SummonerSpellType>> summonerSpellCollection = new LocalizableEnum<SummonerSpellType>[]
        {
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.None,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "None"),
                    new LanguageObject("es-ES", "Ninguno")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.Cleanse,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Cleanse"),
                    new LanguageObject("es-ES", "Limpiar")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.Exhaust,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Exhaust"),
                    new LanguageObject("es-ES", "Extenuación")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.Flash,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Flash"),
                    new LanguageObject("es-ES", "Destello")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.WierdMark,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Wierd Mark"),
                    new LanguageObject("es-ES", "Marca Rara")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.Ghost,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Ghost"),
                    new LanguageObject("es-ES", "Fantasmal")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.Heal,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Heal"),
                    new LanguageObject("es-ES", "Curar")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.Smite,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Smite"),
                    new LanguageObject("es-ES", "Aplastar")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.Teleport,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Teleport"),
                    new LanguageObject("es-ES", "Teleportación")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.Clarity,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Clarity"),
                    new LanguageObject("es-ES", "Claridad")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.Ignite,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Ignite"),
                    new LanguageObject("es-ES", "Prender")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.Barrier,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Barrier"),
                    new LanguageObject("es-ES", "Barrera")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.PoroKingCookie,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Poro King Cookie"),
                    new LanguageObject("es-ES", "Galleta del Rey Poro")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.PoroKingMark,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Poro King Mark"),
                    new LanguageObject("es-ES", "Marca del Rey Poro")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.Mark,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Mark"),
                    new LanguageObject("es-ES", "Marca")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.Mark_1,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Mark"),
                    new LanguageObject("es-ES", "Marca")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.AscensionRevive,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Revive"),
                    new LanguageObject("es-ES", "Revivir")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.Ghost_1,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Ghost"),
                    new LanguageObject("es-ES", "Fantasmal")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.Dash,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Dash"),
                    new LanguageObject("es-ES", "Deslizamiento")
                ])
            ),
            new LocalizableEnum<SummonerSpellType>(SummonerSpellType.RuinedKingSmite,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Ruined King Smite"),
                    new LanguageObject("es-ES", "Aplastar del Rey Arruinado")
                ])
            )

        }.ToFrozenSet();

        public static readonly FrozenSet<LocalizableEnum<ThemeType>> themeTypeCollection = new LocalizableEnum<ThemeType>[]
        {
            new LocalizableEnum<ThemeType>(ThemeType.Default,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "System"),
                    new LanguageObject("es-ES", "Sistema")
                ])
            ),
            new LocalizableEnum<ThemeType>(ThemeType.Light,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Light"),
                    new LanguageObject("es-ES", "Claro")
                ])
            ),
            new LocalizableEnum<ThemeType>(ThemeType.Dark,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Dark"),
                    new LanguageObject("es-ES", "Oscuro")
                ])
            )

        }.ToFrozenSet();

        public static readonly FrozenSet<LocalizableEnum<Language>> languageCollection = new LocalizableEnum<Language>[]
        {
            new LocalizableEnum<Language>(Language.English,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "English"),
                    new LanguageObject("es-ES", "Inglés")
                ])
            ),
            new LocalizableEnum<Language>(Language.Spanish,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Spanish"),
                    new LanguageObject("es-ES", "Español")
                ])
            )

        }.ToFrozenSet();

        public static readonly FrozenSet<LocalizableEnum<Region>> regionCollection = new LocalizableEnum<Region>[]
        {
            new LocalizableEnum<Region>(Region.EUW,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Europe West"),
                    new LanguageObject("es-ES", "Europa del Oeste")
                ])
            ),
            new LocalizableEnum<Region>(Region.EUNE,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Europe Nordic & East"),
                    new LanguageObject("es-ES", "Europa Nórdica y del Este")
                ])
            ),
            new LocalizableEnum<Region>(Region.NA,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "North America"),
                    new LanguageObject("es-ES", "Norteamérica")
                ])
            ),
            new LocalizableEnum<Region>(Region.KR,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Korea"),
                    new LanguageObject("es-ES", "Corea")
                ])
            ),
            new LocalizableEnum<Region>(Region.RU,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Russia"),
                    new LanguageObject("es-ES", "Rusia")
                ])
            ),
            new LocalizableEnum<Region>(Region.BR,
                new LocalizableString(
                [
                    new LanguageObject("en-EN", "Brazil"),
                    new LanguageObject("es-ES", "Brasil")
                ])
            )

        }.ToFrozenSet();


        public static string GetChampionDisplayName(ChampionType championType)
        {
            LocalizableEnum<ChampionType> localizableObject = championCollection.FirstOrDefault(item => item.EnumValue == championType);

            return localizableObject.DisplayName;
        }

        public static string GetDisplayName<TEnum>(this TEnum enumValue) where TEnum : Enum
        {
            Type enumType = enumValue.GetType();

            if (enumType == typeof(ChampionType))
            {
                return championCollection.FirstOrDefault(item => item.EnumValue.Equals(enumValue)).DisplayName;
            }
            if (enumType == typeof(RuneType))
            {
                return runeCollection.FirstOrDefault(item => item.EnumValue.Equals(enumValue)).DisplayName;
            }
            if (enumType == typeof(SummonerSpellType))
            {
                return summonerSpellCollection.FirstOrDefault(item => item.EnumValue.Equals(enumValue)).DisplayName;
            }
            if (enumType == typeof(ThemeType))
            {
                return themeTypeCollection.FirstOrDefault(item => item.EnumValue.Equals(enumValue)).DisplayName;
            }
            if (enumType == typeof(Language))
            {
                return languageCollection.FirstOrDefault(item => item.EnumValue.Equals(enumValue)).DisplayName;
            }
            if (enumType == typeof(Region))
            {
                return regionCollection.FirstOrDefault(item => item.EnumValue.Equals(enumValue)).DisplayName;
            }
            return enumValue.ToString();
        }
    }
}
