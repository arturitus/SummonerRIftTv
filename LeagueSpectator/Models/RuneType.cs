namespace LeagueSpectator.Models
{
    public enum RuneType : short
    {
        [LocalizationField("en-EN", "Health per level")]
        [LocalizationField("es-ES", "Vida por nivel")]
        HitPointsPerLevel = 5001,
        [LocalizationField("en-EN", "Armor")]
        [LocalizationField("es-ES", "Armadura")]
        Armor = 5002,
        [LocalizationField("en-EN", "Magic Resist")]
        [LocalizationField("es-ES", "Resistencia mágica")]
        MagicResist = 5003,
        [LocalizationField("en-EN", "Attack speed")]
        [LocalizationField("es-ES", "Velocidad de ataque")]
        AttackSpeed = 5005,
        [LocalizationField("en-EN", "Cooldown reduction per level")]
        [LocalizationField("es-ES", "Reducción de enfriamiento por nivel")]
        CooldownReductionPerLevel = 5007,
        [LocalizationField("en-EN", "Adaptative force")]
        [LocalizationField("es-ES", "Fuerza adaptativa")]
        AdaptativeForce = 5008,
        [LocalizationField("en-EN", "Precision")]
        [LocalizationField("es-ES", "Precisión")]
        Precision = 8000,
        [LocalizationField("en-EN", "Press the attack")]
        [LocalizationField("es-ES", "Ataque intensificado")]
        PressTheAttack = 8005,
        [LocalizationField("en-EN", "Lethal tempo")]
        [LocalizationField("es-ES", "Compás letal")]
        LethalTempo = 8008,
        [LocalizationField("en-EN", "Pressence of mind")]
        [LocalizationField("es-ES", "Claridad mental")]
        PressenceOfMind = 8009,
        [LocalizationField("en-EN", "Conqueror")]
        [LocalizationField("es-ES", "Conquistador")]
        Conqueror = 8010,
        [LocalizationField("en-EN", "Coup of grace")]
        [LocalizationField("es-ES", "Golpe de gracia")]
        CoupOfGrace = 8014,
        [LocalizationField("en-EN", "Cut down")]
        [LocalizationField("es-ES", "Derribado")]
        CutDown = 8017,
        [LocalizationField("en-EN", "Fleet footwork")]
        [LocalizationField("es-ES", "Pies veloces")]
        FleetFootwork = 8021,
        [LocalizationField("en-EN", "Domination")]
        [LocalizationField("es-ES", "Dominación")]
        Domination = 8100,
        [LocalizationField("en-EN", "Relentless hunter")]
        [LocalizationField("es-ES", "Cazador incensante")]
        RelentlessHunter = 8105,
        [LocalizationField("en-EN", "Definitive hunter")]
        [LocalizationField("es-ES", "Cazador definitivo")]
        DefinitiveHunter = 8106,
        [LocalizationField("en-EN", "Electrocute")]
        [LocalizationField("es-ES", "Electrocutar")]
        Electrocute = 8112,
        [LocalizationField("en-EN", "Poro ward")]
        [LocalizationField("es-ES", "Poro fantasmal")]
        PoroWard = 8120,
        [LocalizationField("en-EN", "Predator")]
        [LocalizationField("es-ES", "Depredador")]
        Predator = 8124,
        [LocalizationField("en-EN", "Cheap shot")]
        [LocalizationField("es-ES", "Golpe bajo")]
        CheapShot = 8126,
        [LocalizationField("en-EN", "Dark harvest")]
        [LocalizationField("es-ES", "Cosecha oscura")]
        DarkHarvest = 8128,
        [LocalizationField("en-EN", "Ingenious hunter")]
        [LocalizationField("es-ES", "Cazador ingenioso")]
        IngeniousHunter = 8134,
        [LocalizationField("en-EN", "Treasure hunter")]
        [LocalizationField("es-ES", "Cazador de tesoros")]
        TreasureHunter = 8135,
        [LocalizationField("en-EN", "Zombie ward")]
        [LocalizationField("es-ES", "Guardián zombi")]
        ZombieWard = 8136,
        [LocalizationField("en-EN", "Eyeball collection")]
        [LocalizationField("es-ES", "Colección de globos oculares")]
        EyeballCollection = 8138,
        [LocalizationField("en-EN", "Taste of blood")]
        [LocalizationField("es-ES", "Sabor a sangre")]
        TasteOfBlood = 8139,
        [LocalizationField("en-EN", "Sudden impact")]
        [LocalizationField("es-ES", "Impacto repentino")]
        SuddenImpact = 8143,
        [LocalizationField("en-EN", "Sorcery")]
        [LocalizationField("es-ES", "Brujería")]
        Sorcery = 8200,
        [LocalizationField("en-EN", "Trascendence")]
        [LocalizationField("es-ES", "Trascendencia")]
        Trascendence = 8210,
        [LocalizationField("en-EN", "Summon Aery")]
        [LocalizationField("es-ES", "Invocar a Aery")]
        SummonAery = 8214,
        [LocalizationField("en-EN", "Nullifying orb")]
        [LocalizationField("es-ES", "Orbe anulador")]
        NullifyingOrb = 8224,
        [LocalizationField("en-EN", "Manaflow band")]
        [LocalizationField("es-ES", "Banda de mána")]
        ManaflowBand = 8226,
        [LocalizationField("en-EN", "Arcane comet")]
        [LocalizationField("es-ES", "Cometa arcano")]
        ArcaneComet = 8229,
        [LocalizationField("en-EN", "Phase rush")]
        [LocalizationField("es-ES", "Irrupción de fase")]
        PhaseRush = 8230,
        [LocalizationField("en-EN", "Water walking")]
        [LocalizationField("es-ES", "Caminar sobre agua")]
        Waterwalking = 8232,
        [LocalizationField("en-EN", "Absolute focus")]
        [LocalizationField("es-ES", "Concentración absoluta")]
        AbsoluteFocus = 8233,
        [LocalizationField("en-EN", "Celerity")]
        [LocalizationField("es-ES", "Celeridad")]
        Celerity = 8234,
        [LocalizationField("en-EN", "Gathering storm")]
        [LocalizationField("es-ES", "Se avecina tormenta")]
        GatheringStorm = 8236,
        [LocalizationField("en-EN", "Scorch")]
        [LocalizationField("es-ES", "Piroláser")]
        Scorch = 8237,
        [LocalizationField("en-EN", "Unflinching")]
        [LocalizationField("es-ES", "Inquebrantable")]
        Unflinching = 8242,
        [LocalizationField("en-EN", "Nimbus cloak")]
        [LocalizationField("es-ES", "Capa del nimbo")]
        NimbusCloak = 8275,
        [LocalizationField("en-EN", "Last stand")]
        [LocalizationField("es-ES", "Último esfuerzo")]
        LastStand = 8299,
        [LocalizationField("en-EN", "Inspiration")]
        [LocalizationField("es-ES", "Inspiración")]
        Inspiration = 8300,
        [LocalizationField("en-EN", "Magical footwear")]
        [LocalizationField("es-ES", "Calzado mágico")]
        MagicalFootwear = 8304,
        [LocalizationField("en-EN", "Hextech flashtraption")]
        [LocalizationField("es-ES", "Destello Hexflash")]
        HextechFlashtraption = 8306,
        [LocalizationField("en-EN", "Perfect timing")]
        [LocalizationField("es-ES", "Momento oportuno")]
        PerfectTiming = 8313,
        [LocalizationField("en-EN", "Minion dematerializer")]
        [LocalizationField("es-ES", "Desmaterializador de súbditos")]
        MinionDematerializer = 8316,
        [LocalizationField("en-EN", "Future's market")]
        [LocalizationField("es-ES", "Mercado del futuro")]
        FuturesMarket = 8321,
        [LocalizationField("en-EN", "Biscuit delivery")]
        [LocalizationField("es-ES", "Entrega de galletas")]
        BiscuitDelivery = 8345,
        [LocalizationField("en-EN", "Cosmic insight")]
        [LocalizationField("es-ES", "Perspicacia cósmica")]
        CosmicInsight = 8347,
        [LocalizationField("en-EN", "Glacial augment")]
        [LocalizationField("es-ES", "Aumento glacial")]
        GlacialAugment = 8351,
        [LocalizationField("en-EN", "Time warp tonic")]
        [LocalizationField("es-ES", "Tónico de distorsion temporal")]
        TimeWarpTonic = 8352,
        [LocalizationField("en-EN", "Unsealed spellbook")]
        [LocalizationField("es-ES", "Libro de hechizos")]
        UnsealedSpellbook = 8360,
        [LocalizationField("en-EN", "First strike")]
        [LocalizationField("es-ES", "Primer golpe")]
        FirstStrike = 8369,
        [LocalizationField("en-EN", "Resolve")]
        [LocalizationField("es-ES", "Valor")]
        Resolve = 8400,
        [LocalizationField("en-EN", "Shield bash")]
        [LocalizationField("es-ES", "Golpe de escudo")]
        ShieldBash = 8401,
        [LocalizationField("en-EN", "Approach velocity")]
        [LocalizationField("es-ES", "Velocidad de acercamiento")]
        ApproachVelocity = 8410,
        [LocalizationField("en-EN", "Conditioning")]
        [LocalizationField("es-ES", "Condicionamiento")]
        Conditioning = 8429,
        [LocalizationField("en-EN", "Grasp of the Undiying")]
        [LocalizationField("es-ES", "Garras del inmortal")]
        GraspOfTheUndiying = 8437,
        [LocalizationField("en-EN", "Aftershock")]
        [LocalizationField("es-ES", "Reverberacción")]
        Aftershock = 8439,
        [LocalizationField("en-EN", "Second wind")]
        [LocalizationField("es-ES", "Fuerzas renovadas")]
        SecondWind = 8444,
        [LocalizationField("en-EN", "Demolish")]
        [LocalizationField("es-ES", "Demoler")]
        Demolish = 8446,
        [LocalizationField("en-EN", "Overgrowth")]
        [LocalizationField("es-ES", "Sobrecrecimiento")]
        Overgrowth = 8451,
        [LocalizationField("en-EN", "Revitalize")]
        [LocalizationField("es-ES", "Revitalizar")]
        Revitalize = 8453,
        [LocalizationField("en-EN", "Font of life")]
        [LocalizationField("es-ES", "Fuente de vida")]
        FontOfLife = 8463,
        [LocalizationField("en-EN", "Guardian")]
        [LocalizationField("es-ES", "Protector")]
        Guardian = 8465,
        [LocalizationField("en-EN", "Bone plating")]
        [LocalizationField("es-ES", "Revestimiento de huesos")]
        BonePlating = 8473,
        [LocalizationField("en-EN", "Overheal")]
        [LocalizationField("es-ES", "Supercuración")]
        Overheal = 9101,
        [LocalizationField("en-EN", "Legend: Bloodline")]
        [LocalizationField("es-ES", "Leyenda: Linaje")]
        LegendBloodline = 9103,
        [LocalizationField("en-EN", "Leyenda: Alacrity")]
        [LocalizationField("es-ES", "Leyenda: Presteza")]
        LegendAlacrity = 9104,
        [LocalizationField("en-EN", "Leyenda: Tenacity")]
        [LocalizationField("es-ES", "Leyenda: Tenacidad")]
        LegendTenacity = 9105,
        [LocalizationField("en-EN", "Triumph")]
        [LocalizationField("es-ES", "Triunfo")]
        Triumph = 9111,
        [LocalizationField("en-EN", "Hail of Blades")]
        [LocalizationField("es-ES", "Lluvia de cuchillas")]
        HailOfBlades = 9923
    }
}
