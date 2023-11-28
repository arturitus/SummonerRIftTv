namespace LeagueSpectator.MVVM.Models
{
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
}

