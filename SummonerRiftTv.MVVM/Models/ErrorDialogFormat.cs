namespace SummonerRiftTv.MVVM.Models
{
    public readonly struct ErrorDialogFormat(string parameter, InfoDialogKeys dialogKeys)
    {
        public string Parameter { get; } = parameter;

        public InfoDialogKeys DialogKeys { get; } = dialogKeys;
    }
}
