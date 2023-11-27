namespace LeagueSpectator.Models
{
    public enum Region
    {
        [LocalizationField("en-EN", "Europe West")]
        [LocalizationField("es-ES", "Europa del Oeste")]
        EUW,
        [LocalizationField("en-EN", "Europe Nordic & East")]
        [LocalizationField("es-ES", "Europa Nórdica y del Este")]
        EUNE,
        [LocalizationField("en-EN", "North America")]
        [LocalizationField("es-ES", "Norteamérica")]
        NA,
        [LocalizationField("en-EN", "Korea")]
        [LocalizationField("es-ES", "Corea")]
        KR,
        [LocalizationField("en-EN", "Russia")]
        [LocalizationField("es-ES", "Rusia")]
        RU,
        [LocalizationField("en-EN", "Brazil")]
        [LocalizationField("es-ES", "Brasil")]
        BR
    }
}
