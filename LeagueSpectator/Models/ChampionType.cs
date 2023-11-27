using System;
using System.Globalization;

namespace LeagueSpectator.Models
{
    public enum ChampionType : short
    {
        [LocalizationField("en-EN", "None")]
        [LocalizationField("es-ES", "Ninguno")]
        None = -1,
        [LocalizationField("en-EN", "Annie")]
        [LocalizationField("es-ES", "Annie")]
        Annie = 1,
        [LocalizationField("en-EN", "Kayle")]
        [LocalizationField("es-ES", "Kayle")]
        Kayle = 10,
        [LocalizationField("en-EN", "Xerath")]
        [LocalizationField("es-ES", "Xerath")]
        Xerath = 101,
        [LocalizationField("en-EN", "Shyvana")]
        [LocalizationField("es-ES", "Shyvana")]
        Shyvana = 102,
        [LocalizationField("en-EN", "Ahri")]
        [LocalizationField("es-ES", "Ahri")]
        Ahri = 103,
        [LocalizationField("en-EN", "Graves")]
        [LocalizationField("es-ES", "Graves")]
        Graves = 104,
        [LocalizationField("en-EN", "Fizz")]
        [LocalizationField("es-ES", "Fizz")]
        Fizz = 105,
        [LocalizationField("en-EN", "Volibear")]
        [LocalizationField("es-ES", "Volibear")]
        Volibear = 106,
        [LocalizationField("en-EN", "Rengar")]
        [LocalizationField("es-ES", "Rengar")]
        Rengar = 107,
        [LocalizationField("en-EN", "MasterYi")]
        [LocalizationField("es-ES", "Maestro Yi")]
        MasterYi = 11,
        [LocalizationField("en-EN", "Varus")]
        [LocalizationField("es-ES", "Varus")]
        Varus = 110,
        [LocalizationField("en-EN", "Nautilus")]
        [LocalizationField("es-ES", "Nautilus")]
        Nautilus = 111,
        [LocalizationField("en-EN", "Viktor")]
        [LocalizationField("es-ES", "Viktor")]
        Viktor = 112,
        [LocalizationField("en-EN", "Sejuani")]
        [LocalizationField("es-ES", "Sejuani")]
        Sejuani = 113,
        [LocalizationField("en-EN", "Fiora")]
        [LocalizationField("es-ES", "Fiora")]
        Fiora = 114,
        [LocalizationField("en-EN", "Ziggs")]
        [LocalizationField("es-ES", "Ziggs")]
        Ziggs = 115,
        [LocalizationField("en-EN", "Lulu")]
        [LocalizationField("es-ES", "Lulu")]
        Lulu = 117,
        [LocalizationField("en-EN", "Draven")]
        [LocalizationField("es-ES", "Draven")]
        Draven = 119,
        [LocalizationField("en-EN", "Alistar")]
        [LocalizationField("es-ES", "Alistar")]
        Alistar = 12,
        [LocalizationField("en-EN", "Hecarim")]
        [LocalizationField("es-ES", "Hecarim")]
        Hecarim = 120,
        [LocalizationField("en-EN", "Kha'Zix")]
        [LocalizationField("es-ES", "Kha'Zix")]
        KhaZix = 121,
        [LocalizationField("en-EN", "Darius")]
        [LocalizationField("es-ES", "Darius")]
        Darius = 122,
        [LocalizationField("en-EN", "Jayce")]
        [LocalizationField("es-ES", "Jayce")]
        Jayce = 126,
        [LocalizationField("en-EN", "Lissandra")]
        [LocalizationField("es-ES", "Lissandra")]
        Lissandra = 127,
        [LocalizationField("en-EN", "Ryze")]
        [LocalizationField("es-ES", "Ryze")]
        Ryze = 13,
        [LocalizationField("en-EN", "Diana")]
        [LocalizationField("es-ES", "Diana")]
        Diana = 131,
        [LocalizationField("en-EN", "Quinn")]
        [LocalizationField("es-ES", "Quinn")]
        Quinn = 133,
        [LocalizationField("en-EN", "Syndra")]
        [LocalizationField("es-ES", "Syndra")]
        Syndra = 134,
        [LocalizationField("en-EN", "Aurelion Sol")]
        [LocalizationField("es-ES", "Aurelion Sol")]
        AurelionSol = 136,
        [LocalizationField("en-EN", "Sion")]
        [LocalizationField("es-ES", "Sion")]
        Sion = 14,
        [LocalizationField("en-EN", "Kayn")]
        [LocalizationField("es-ES", "Kayn")]
        Kayn = 141,
        [LocalizationField("en-EN", "Zoe")]
        [LocalizationField("es-ES", "Zoe")]
        Zoe = 142,
        [LocalizationField("en-EN", "Zyra")]
        [LocalizationField("es-ES", "Zyra")]
        Zyra = 143,
        [LocalizationField("en-EN", "Kai'Sa")]
        [LocalizationField("es-ES", "Kai'Sa")]
        Kaisa = 145,
        [LocalizationField("en-EN", "Seraphine")]
        [LocalizationField("es-ES", "Seraphine")]
        Seraphine = 147,
        [LocalizationField("en-EN", "Sivir")]
        [LocalizationField("es-ES", "Sivir")]
        Sivir = 15,
        [LocalizationField("en-EN", "Gnar")]
        [LocalizationField("es-ES", "Gnar")]
        Gnar = 150,
        [LocalizationField("en-EN", "Zac")]
        [LocalizationField("es-ES", "Zac")]
        Zac = 154,
        [LocalizationField("en-EN", "Yasuo")]
        [LocalizationField("es-ES", "Yasuo")]
        Yasuo = 157,
        [LocalizationField("en-EN", "Soraka")]
        [LocalizationField("es-ES", "Soraka")]
        Soraka = 16,
        [LocalizationField("en-EN", "Vel'Koz")]
        [LocalizationField("es-ES", "Vel'Koz")]
        Velkoz = 161,
        [LocalizationField("en-EN", "Taliyah")]
        [LocalizationField("es-ES", "Taliyah")]
        Taliyah = 163,
        [LocalizationField("en-EN", "Camille")]
        [LocalizationField("es-ES", "Camille")]
        Camille = 164,
        [LocalizationField("en-EN", "Akshan")]
        [LocalizationField("es-ES", "Akshan")]
        Akshan = 166,
        [LocalizationField("en-EN", "Teemo")]
        [LocalizationField("es-ES", "Teemo")]
        Teemo = 17,
        [LocalizationField("en-EN", "Tristana")]
        [LocalizationField("es-ES", "Tristana")]
        Tristana = 18,
        [LocalizationField("en-EN", "Warwick")]
        [LocalizationField("es-ES", "Warwick")]
        Warwick = 19,
        [LocalizationField("en-EN", "Olaf")]
        [LocalizationField("es-ES", "Olaf")]
        Olaf = 2,
        [LocalizationField("en-EN", "Nunu")]
        [LocalizationField("es-ES", "Nunu")]
        Nunu = 20,
        [LocalizationField("en-EN", "Bel'Veth")]
        [LocalizationField("es-ES", "Bel'Veth")]
        Belveth = 200,
        [LocalizationField("en-EN", "Braum")]
        [LocalizationField("es-ES", "Braum")]
        Braum = 201,
        [LocalizationField("en-EN", "Jhin")]
        [LocalizationField("es-ES", "Jhin")]
        Jhin = 202,
        [LocalizationField("en-EN", "Kindred")]
        [LocalizationField("es-ES", "Kindred")]
        Kindred = 203,
        [LocalizationField("en-EN", "Miss Fortune")]
        [LocalizationField("es-ES", "Miss Fortune")]
        MissFortune = 21,
        [LocalizationField("en-EN", "Ashe")]
        [LocalizationField("es-ES", "Ashe")]
        Ashe = 22,
        [LocalizationField("en-EN", "Zeri")]
        [LocalizationField("es-ES", "Zeri")]
        Zeri = 221,
        [LocalizationField("en-EN", "Jinx")]
        [LocalizationField("es-ES", "Jinx")]
        Jinx = 222,
        [LocalizationField("en-EN", "Tahm Kench")]
        [LocalizationField("es-ES", "Tahm Kench")]
        TahmKench = 223,
        [LocalizationField("en-EN", "Tryndamere")]
        [LocalizationField("es-ES", "Tryndamere")]
        Tryndamere = 23,
        [LocalizationField("en-EN", "Briar")]
        [LocalizationField("es-ES", "Briar")]
        Briar = 233,
        [LocalizationField("en-EN", "Viego")]
        [LocalizationField("es-ES", "Viego")]
        Viego = 234,
        [LocalizationField("en-EN", "Senna")]
        [LocalizationField("es-ES", "Senna")]
        Senna = 235,
        [LocalizationField("en-EN", "Lucian")]
        [LocalizationField("es-ES", "Lucian")]
        Lucian = 236,
        [LocalizationField("en-EN", "Zed")]
        [LocalizationField("es-ES", "Zed")]
        Zed = 238,
        [LocalizationField("en-EN", "Jax")]
        [LocalizationField("es-ES", "Jax")]
        Jax = 24,
        [LocalizationField("en-EN", "Kled")]
        [LocalizationField("es-ES", "Kled")]
        Kled = 240,
        [LocalizationField("en-EN", "Ekko")]
        [LocalizationField("es-ES", "Ekko")]
        Ekko = 245,
        [LocalizationField("en-EN", "Qiyana")]
        [LocalizationField("es-ES", "Qiyana")]
        Qiyana = 246,
        [LocalizationField("en-EN", "Morgana")]
        [LocalizationField("es-ES", "Morgana")]
        Morgana = 25,
        [LocalizationField("en-EN", "Vi")]
        [LocalizationField("es-ES", "Vi")]
        Vi = 254,
        [LocalizationField("en-EN", "Zilean")]
        [LocalizationField("es-ES", "Zilean")]
        Zilean = 26,
        [LocalizationField("en-EN", "Aatrox")]
        [LocalizationField("es-ES", "Aatrox")]
        Aatrox = 266,
        [LocalizationField("en-EN", "Nami")]
        [LocalizationField("es-ES", "Nami")]
        Nami = 267,
        [LocalizationField("en-EN", "Azir")]
        [LocalizationField("es-ES", "Azir")]
        Azir = 268,
        [LocalizationField("en-EN", "Singed")]
        [LocalizationField("es-ES", "Singed")]
        Singed = 27,
        [LocalizationField("en-EN", "Evelynn")]
        [LocalizationField("es-ES", "Evelynn")]
        Evelynn = 28,
        [LocalizationField("en-EN", "Twitch")]
        [LocalizationField("es-ES", "Twitch")]
        Twitch = 29,
        [LocalizationField("en-EN", "Galio")]
        [LocalizationField("es-ES", "Galio")]
        Galio = 3,
        [LocalizationField("en-EN", "Karthus")]
        [LocalizationField("es-ES", "Karthus")]
        Karthus = 30,
        [LocalizationField("en-EN", "Cho'Gath")]
        [LocalizationField("es-ES", "Cho'Gath")]
        ChoGath = 31,
        [LocalizationField("en-EN", "Amumu")]
        [LocalizationField("es-ES", "Amumu")]
        Amumu = 32,
        [LocalizationField("en-EN", "Rammus")]
        [LocalizationField("es-ES", "Rammus")]
        Rammus = 33,
        [LocalizationField("en-EN", "Anivia")]
        [LocalizationField("es-ES", "Anivia")]
        Anivia = 34,
        [LocalizationField("en-EN", "Shaco")]
        [LocalizationField("es-ES", "Shaco")]
        Shaco = 35,
        [LocalizationField("en-EN", "Yuumi")]
        [LocalizationField("es-ES", "Yuumi")]
        Yuumi = 350,
        [LocalizationField("en-EN", "Dr. Mundo")]
        [LocalizationField("es-ES", "Dr. Mundo")]
        DrMundo = 36,
        [LocalizationField("en-EN", "Samira")]
        [LocalizationField("es-ES", "Samira")]
        Samira = 360,
        [LocalizationField("en-EN", "Sona")]
        [LocalizationField("es-ES", "Sona")]
        Sona = 37,
        [LocalizationField("en-EN", "Kassadin")]
        [LocalizationField("es-ES", "Kassadin")]
        Kassadin = 38,
        [LocalizationField("en-EN", "Irelia")]
        [LocalizationField("es-ES", "Irelia")]
        Irelia = 39,
        [LocalizationField("en-EN", "Twisted Fate")]
        [LocalizationField("es-ES", "Twisted Fate")]
        TwistedFate = 4,
        [LocalizationField("en-EN", "Janna")]
        [LocalizationField("es-ES", "Janna")]
        Janna = 40,
        [LocalizationField("en-EN", "Gangplank")]
        [LocalizationField("es-ES", "Gangplank")]
        Gangplank = 41,
        [LocalizationField("en-EN", "Thresh")]
        [LocalizationField("es-ES", "Thresh")]
        Thresh = 412,
        [LocalizationField("en-EN", "Corki")]
        [LocalizationField("es-ES", "Corki")]
        Corki = 42,
        [LocalizationField("en-EN", "Illaoi")]
        [LocalizationField("es-ES", "Illaoi")]
        Illaoi = 420,
        [LocalizationField("en-EN", "Rek'Sai")]
        [LocalizationField("es-ES", "Rek'Sai")]
        RekSai = 421,
        [LocalizationField("en-EN", "Ivern")]
        [LocalizationField("es-ES", "Ivern")]
        Ivern = 427,
        [LocalizationField("en-EN", "Kalista")]
        [LocalizationField("es-ES", "Kalista")]
        Kalista = 429,
        [LocalizationField("en-EN", "Karma")]
        [LocalizationField("es-ES", "Karma")]
        Karma = 43,
        [LocalizationField("en-EN", "Bard")]
        [LocalizationField("es-ES", "Bardo")]
        Bard = 432,
        [LocalizationField("en-EN", "Taric")]
        [LocalizationField("es-ES", "Taric")]
        Taric = 44,
        [LocalizationField("en-EN", "Veigar")]
        [LocalizationField("es-ES", "Veigar")]
        Veigar = 45,
        [LocalizationField("en-EN", "Trundle")]
        [LocalizationField("es-ES", "Trundle")]
        Trundle = 48,
        [LocalizationField("en-EN", "Rakan")]
        [LocalizationField("es-ES", "Rakan")]
        Rakan = 497,
        [LocalizationField("en-EN", "Xayah")]
        [LocalizationField("es-ES", "Xayah")]
        Xayah = 498,
        [LocalizationField("en-EN", "Xin Zhao")]
        [LocalizationField("es-ES", "Xin Zhao")]
        XinZhao = 5,
        [LocalizationField("en-EN", "Swain")]
        [LocalizationField("es-ES", "Swain")]
        Swain = 50,
        [LocalizationField("en-EN", "Caitlyn")]
        [LocalizationField("es-ES", "Caitlyn")]
        Caitlyn = 51,
        [LocalizationField("en-EN", "Ornn")]
        [LocalizationField("es-ES", "Ornn")]
        Ornn = 516,
        [LocalizationField("en-EN", "Sylas")]
        [LocalizationField("es-ES", "Sylas")]
        Sylas = 517,
        [LocalizationField("en-EN", "Neeko")]
        [LocalizationField("es-ES", "Neeko")]
        Neeko = 518,
        [LocalizationField("en-EN", "Aphelios")]
        [LocalizationField("es-ES", "Aphelios")]
        Aphelios = 523,
        [LocalizationField("en-EN", "Rell")]
        [LocalizationField("es-ES", "Rell")]
        Rell = 526,
        [LocalizationField("en-EN", "Blitzcrank")]
        [LocalizationField("es-ES", "Blitzcrank")]
        Blitzcrank = 53,
        [LocalizationField("en-EN", "Malphite")]
        [LocalizationField("es-ES", "Malphite")]
        Malphite = 54,
        [LocalizationField("en-EN", "Katarina")]
        [LocalizationField("es-ES", "Katarina")]
        Katarina = 55,
        [LocalizationField("en-EN", "Pyke")]
        [LocalizationField("es-ES", "Pyke")]
        Pyke = 555,
        [LocalizationField("en-EN", "Nocturne")]
        [LocalizationField("es-ES", "Nocturne")]
        Nocturne = 56,
        [LocalizationField("en-EN", "Maokai")]
        [LocalizationField("es-ES", "Maokai")]
        Maokai = 57,
        [LocalizationField("en-EN", "Renekton")]
        [LocalizationField("es-ES", "Renekton")]
        Renekton = 58,
        [LocalizationField("en-EN", "Jarvan IV")]
        [LocalizationField("es-ES", "Jarvan IV")]
        JarvanIV = 59,
        [LocalizationField("en-EN", "Urgot")]
        [LocalizationField("es-ES", "Urgot")]
        Urgot = 6,
        [LocalizationField("en-EN", "Elise")]
        [LocalizationField("es-ES", "Elise")]
        Elise = 60,
        [LocalizationField("en-EN", "Orianna")]
        [LocalizationField("es-ES", "Orianna")]
        Orianna = 61,
        [LocalizationField("en-EN", "Wukong")]
        [LocalizationField("es-ES", "Wukong")]
        Wukong = 62,
        [LocalizationField("en-EN", "Brand")]
        [LocalizationField("es-ES", "Brand")]
        Brand = 63,
        [LocalizationField("en-EN", "Lee Sin")]
        [LocalizationField("es-ES", "Lee Sin")]
        LeeSin = 64,
        [LocalizationField("en-EN", "Vayne")]
        [LocalizationField("es-ES", "Vayne")]
        Vayne = 67,
        [LocalizationField("en-EN", "Rumble")]
        [LocalizationField("es-ES", "Rumble")]
        Rumble = 68,
        [LocalizationField("en-EN", "Cassiopeia")]
        [LocalizationField("es-ES", "Cassiopeia")]
        Cassiopeia = 69,
        [LocalizationField("en-EN", "LeBlanc")]
        [LocalizationField("es-ES", "LeBlanc")]
        LeBlanc = 7,
        [LocalizationField("en-EN", "Vex")]
        [LocalizationField("es-ES", "Vex")]
        Vex = 711,
        [LocalizationField("en-EN", "Skarner")]
        [LocalizationField("es-ES", "Skarner")]
        Skarner = 72,
        [LocalizationField("en-EN", "Heimerdinger")]
        [LocalizationField("es-ES", "Heimerdinger")]
        Heimerdinger = 74,
        [LocalizationField("en-EN", "Nasus")]
        [LocalizationField("es-ES", "Nasus")]
        Nasus = 75,
        [LocalizationField("en-EN", "Nidalee")]
        [LocalizationField("es-ES", "Nidalee")]
        Nidalee = 76,
        [LocalizationField("en-EN", "Udyr")]
        [LocalizationField("es-ES", "Udyr")]
        Udyr = 77,
        [LocalizationField("en-EN", "Yone")]
        [LocalizationField("es-ES", "Yone")]
        Yone = 777,
        [LocalizationField("en-EN", "Poppy")]
        [LocalizationField("es-ES", "Poppy")]
        Poppy = 78,
        [LocalizationField("en-EN", "Gragas")]
        [LocalizationField("es-ES", "Gragas")]
        Gragas = 79,
        [LocalizationField("en-EN", "Vladirmir")]
        [LocalizationField("es-ES", "Vladirmir")]
        Vladirmir = 8,
        [LocalizationField("en-EN", "Pantheon")]
        [LocalizationField("es-ES", "Pantheon")]
        Pantheon = 80,
        [LocalizationField("en-EN", "Ezreal")]
        [LocalizationField("es-ES", "Ezreal")]
        Ezreal = 81,
        [LocalizationField("en-EN", "Mordekaiser")]
        [LocalizationField("es-ES", "Mordekaiser")]
        Mordekaiser = 82,
        [LocalizationField("en-EN", "Yorick")]
        [LocalizationField("es-ES", "Yorick")]
        Yorick = 83,
        [LocalizationField("en-EN", "Akali")]
        [LocalizationField("es-ES", "Akali")]
        Akali = 84,
        [LocalizationField("en-EN", "Kennen")]
        [LocalizationField("es-ES", "Kennen")]
        Kennen = 85,
        [LocalizationField("en-EN", "Garen")]
        [LocalizationField("es-ES", "Garen")]
        Garen = 86,
        [LocalizationField("en-EN", "Sett")]
        [LocalizationField("es-ES", "Sett")]
        Sett = 875,
        [LocalizationField("en-EN", "Lillia")]
        [LocalizationField("es-ES", "Lillia")]
        Lillia = 876,
        [LocalizationField("en-EN", "Gwen")]
        [LocalizationField("es-ES", "Gwen")]
        Gwen = 887,
        [LocalizationField("en-EN", "Renata Glasc")]
        [LocalizationField("es-ES", "Renata Glasc")]
        RenataGlasc = 888,
        [LocalizationField("en-EN", "Leona")]
        [LocalizationField("es-ES", "Leona")]
        Leona = 89,
        [LocalizationField("en-EN", "Nilah")]
        [LocalizationField("es-ES", "Nilah")]
        Nilah = 895,
        [LocalizationField("en-EN", "K'Sante")]
        [LocalizationField("es-ES", "K'Sante")]
        Ksante = 897,
        [LocalizationField("en-EN", "Fiddlesticks")]
        [LocalizationField("es-ES", "Fiddlesticks")]
        Fiddlesticks = 9,
        [LocalizationField("en-EN", "Malzahar")]
        [LocalizationField("es-ES", "Malzahar")]
        Malzahar = 90,
        [LocalizationField("en-EN", "Talon")]
        [LocalizationField("es-ES", "Talon")]
        Talon = 91,
        [LocalizationField("en-EN", "Riven")]
        [LocalizationField("es-ES", "Riven")]
        Riven = 92,
        [LocalizationField("en-EN", "Naafiri")]
        [LocalizationField("es-ES", "Naafiri")]
        Naafiri = 950,
        [LocalizationField("en-EN", "Kog'Maw")]
        [LocalizationField("es-ES", "Kog'Maw")]
        KogMaw = 96,
        [LocalizationField("en-EN", "Shen")]
        [LocalizationField("es-ES", "Shen")]
        Shen = 98,
        [LocalizationField("en-EN", "Lux")]
        [LocalizationField("es-ES", "Lux")]
        Lux = 99,
    }
    public enum ThemeType
    {
        [LocalizationField("en-EN", "System")]
        [LocalizationField("es-ES", "Sistema")]
        Default,
        [LocalizationField("en-EN", "Light")]
        [LocalizationField("es-ES", "Claro")]
        Light,
        [LocalizationField("en-EN", "Dark")]
        [LocalizationField("es-ES", "Oscuro")]
        Dark
    }

    public enum Language
    {
        //[LocalizationField("es-ES", "Sistema")]
        //[LocalizationField("en-EN", "System")]
        //Default,
        [Culture("en-EN")]
        [LocalizationField("en-EN", "English")]
        [LocalizationField("es-ES", "Inglés")]
        English,
        [Culture("es-ES")]
        [LocalizationField("en-EN", "Spanish")]
        [LocalizationField("es-ES", "Español")]
        Spanish

    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class LocalizationFieldAttribute : Attribute
    {
        public CultureInfo CultureInfo { get; }
        public string DisplayName { get; }

        public LocalizationFieldAttribute(string cultureInfo, string displayName)
        {
            CultureInfo = new CultureInfo(cultureInfo);
            DisplayName = displayName;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CultureAttribute : Attribute
    {
        public CultureInfo CultureInfo { get; }

        public CultureAttribute(string cultureInfo)
        {
            CultureInfo = new CultureInfo(cultureInfo);
        }
    }
}

