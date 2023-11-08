﻿using System;
using System.ComponentModel;
using System.Globalization;

namespace LeagueSpectator.Models
{
    public enum ChampionType : short
    {
        None = -1,
        Annie = 1,
        Kayle = 10,
        Xerath = 101,
        Shyvana = 102,
        Ahri = 103,
        Graves = 104,
        Fizz = 105,
        Volibear = 106,
        Rengar = 107,
        MasterYi = 11,
        Varus = 110,
        Nautilus = 111,
        Viktor = 112,
        Sejuani = 113,
        Fiora = 114,
        Ziggs = 115,
        Lulu = 117,
        Draven = 119,
        Alistar = 12,
        Hecarim = 120,
        KhaZix = 121,
        Darius = 122,
        Jayce = 126,
        Lissandra = 127,
        Ryze = 13,
        Diana = 131,
        Quinn = 133,
        Syndra = 134,
        AurelionSol = 136,
        Sion = 14,
        Kayn = 141,
        Zoe = 142,
        Zyra = 143,
        Kaisa = 145,
        Seraphine = 147,
        Sivir = 15,
        Gnar = 150,
        Zac = 154,
        Yasuo = 157,
        Soraka = 16,
        Velkoz = 161,
        Taliyah = 163,
        Camille = 164,
        Akshan = 166,
        Teemo= 17,
        Tristana = 18,
        Warwick = 19,
        Olaf = 2,
        Nunu = 20,
        Belveth = 200,
        Braum = 201,
        Jhin = 202,
        Kindred = 203,
        MissFortune =21,
        Ashe = 22,
        Zeri = 221,
        Jinx = 222,
        TahmKench = 223,
        Tryndamere =23,
        Briar = 233,
        Viego = 234,
        Senna = 235,
        Lucian = 236,
        Zed = 238,
        Jax = 24,
        Kled = 240,
        Ekko = 245,
        Qiyana = 246,
        Morgana = 25,
        Vi = 254,
        Zilean = 26,
        Aatrox = 266,
        Nami = 267,
        Azir = 268,
        Singed = 27,
        Evelynn = 28,
        Twitch = 29,
        Galio = 3,
        Karthus = 30,
        ChoGath = 31,
        Amumu = 32,
        Rammus = 33,
        Anivia = 34,
        Shaco = 35,
        Yuumi = 350,
        DrMundo = 36,
        Samira = 360,
        Sona = 37,
        Kassadin = 38,
        Irealia = 39,
        TwistedFate = 4,
        Janna = 40,
        Gangplank = 41,
        Thresh = 412,
        Corki = 42,
        Illaoi = 420,
        RekSai = 421,
        Ivern = 427,
        Kalista = 429,
        Karma = 43,
        [LocalizationField("en-EN", "Bard")]
        [LocalizationField("es-ES", "Bardo")]
        Bard = 432,
        Taric =44,
        Veigar = 45,
        Trundle = 48,
        Rakan = 497,
        Xayah = 498,
        XinZhao = 5,
        Swain = 50,
        Caitlyn = 51,
        Ornn = 516,
        Sylas = 517,
        Neeko = 518,
        Aphelios = 523,
        Rell = 526,
        Blitzcrank = 53,
        Malphite = 54,
        Katarina = 55,
        Pyke = 555,
        Nocturne = 56,
        Maokai = 57,
        Renekton = 58,
        JarvanIV = 59,
        Urgot = 6,
        Elise = 60,
        Orianna = 61,
        Wukong = 62,
        Brand = 63,
        LeeSin = 64,
        Vayne = 67,
        Rumble = 68,
        Cassiopeia = 69,
        LeBlanc = 7,
        Vex = 711,
        Skarner = 72,
        Heimerdinger = 74,
        Nasus = 75,
        Nidalee = 76,
        Udyr = 77,
        Yone = 777,
        Poppy = 78,
        Gragas = 79,
        Vladirmir = 8,
        Pantheon = 80,
        Ezreal = 81,
        Mordekaiser = 82,
        Yorick = 83,
        Akali = 84,
        Kennen = 85,
        Garen = 86,
        Sett = 875,
        Lillia = 876,
        Gwen = 887,
        RenataGlasc = 888,
        Leona = 89,
        Nilah = 895,
        Ksante = 897,
        Fiddlesticks = 9,
        Malzahar = 90,
        Talon = 91,
        Riven = 92,
        Naafiri = 950,
        KogMaw = 96,
        Shen = 98,
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

