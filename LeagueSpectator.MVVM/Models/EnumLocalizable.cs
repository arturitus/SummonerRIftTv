namespace LeagueSpectator.MVVM.Models
{
    public class EnumLocalizable
    {
        public Enum EnumValue { get; set; }
        public string DisplayName { get; set; }
    }

    public class EnumLocalizableCollection : List<EnumLocalizable>;
}
