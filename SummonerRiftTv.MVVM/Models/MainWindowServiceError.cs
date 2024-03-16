namespace SummonerRiftTv.MVVM.Models
{
    public class MainWindowServiceError(ErrorDialogFormat errorFormat) : Exception
    {
        public ErrorDialogFormat ErrorFormat { get; set; } = errorFormat;
    }
}
