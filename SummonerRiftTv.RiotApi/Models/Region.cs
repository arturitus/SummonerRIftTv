namespace SummonerRiftTv.RiotApi.Models
{
    public enum Region
    {
        //[LocalizationField("en-EN", "Europe West")]
        //[LocalizationField("es-ES", "Europa del Oeste")]
        EUW1,
        //[LocalizationField("en-EN", "Europe Nordic & East")]
        //[LocalizationField("es-ES", "Europa Nórdica y del Este")]
        EUN1,
        //[LocalizationField("en-EN", "North America")]
        //[LocalizationField("es-ES", "Norteamérica")]
        NA1,
        //[LocalizationField("en-EN", "Korea")]
        //[LocalizationField("es-ES", "Corea")]
        KR,
        //[LocalizationField("en-EN", "Russia")]
        //[LocalizationField("es-ES", "Rusia")]
        RU,
        //[LocalizationField("en-EN", "Brazil")]
        //[LocalizationField("es-ES", "Brasil")]
        BR1
    }

    public enum TagLine
    {
        NA1,
        EUW,
        EUNE,
        OCE,
        KR1,
        JP1,
        BR1,
        LAS,
        LAN,
        RU1,
        TR1,
        SG2,
        PH2,
        TW2,
        VN2,
        TH2,
    }
    public enum RiotServerRegion
    {
        Americas,
        Asia,
        Esports,
        Europe
    }
}
