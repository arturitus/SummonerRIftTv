namespace LeagueSpectator.MVVM.Models
{
    public enum SummonerSpellType : short
    {
        [LocalizationField("en-EN", "None")]
        [LocalizationField("es-ES", "Ninguno")]
        NoneSummoner = 54,
        [LocalizationField("en-EN", "Cleanse")]
        [LocalizationField("es-ES", "Limpiar")]
        Cleanse = 1,
        [LocalizationField("en-EN", "Exhaust")]
        [LocalizationField("es-ES", "Extenuación")]
        Exhaust = 3,
        [LocalizationField("en-EN", "Flash")]
        [LocalizationField("es-ES", "Destello")]
        Flash = 4,
        [LocalizationField("en-EN", "Wierd Mark")]
        [LocalizationField("es-ES", "Marca Rara")]
        WierdMark = 5,
        [LocalizationField("en-EN", "Ghost")]
        [LocalizationField("es-ES", "Fantasmal")]
        Ghost = 6,
        [LocalizationField("en-EN", "Heal")]
        [LocalizationField("es-ES", "Curar")]
        Heal = 7,
        [LocalizationField("en-EN", "Smite")]
        [LocalizationField("es-ES", "Aplastar")]
        Smite = 11,
        [LocalizationField("en-EN", "Teleport")]
        [LocalizationField("es-ES", "Teleportación")]
        Teleport = 12,
        [LocalizationField("en-EN", "Clarity")]
        [LocalizationField("es-ES", "Claridad")]
        Clarity = 13,
        [LocalizationField("en-EN", "Ignite")]
        [LocalizationField("es-ES", "Prender")]
        Ignite = 14,
        [LocalizationField("en-EN", "Barrier")]
        [LocalizationField("es-ES", "Barrera")]
        Barrier = 21,
        [LocalizationField("en-EN", "Poro King Cookie")]
        [LocalizationField("es-ES", "Galleta del Rey Poro")]
        PoroKingCookie = 30,
        [LocalizationField("en-EN", "Poro King Mark")]
        [LocalizationField("es-ES", "Marca del Rey Poro")]
        PoroKingMark = 31,
        [LocalizationField("en-EN", "Mark")]
        [LocalizationField("es-ES", "Marca")]
        Mark = 32,
        [LocalizationField("en-EN", "Mark")]
        [LocalizationField("es-ES", "Marca")]
        Mark_1 = 39,
        [LocalizationField("en-EN", "Revive")]
        [LocalizationField("es-ES", "Revivir")]
        AscensionRevive = 50,
        [LocalizationField("en-EN", "Ghost")]
        [LocalizationField("es-ES", "Fantasmal")]
        Ghost_1 = 51,
        [LocalizationField("en-EN", "Dash")]
        [LocalizationField("es-ES", "Deslizamiento")]
        Dash = 52,
        [LocalizationField("en-EN", "Ruined King Smite")]
        [LocalizationField("es-ES", "Aplastar del Rey Arruinado")]
        RuinedKingSmite = 55,

    }
}
