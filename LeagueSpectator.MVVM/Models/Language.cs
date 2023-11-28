namespace LeagueSpectator.MVVM.Models
{
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
}

