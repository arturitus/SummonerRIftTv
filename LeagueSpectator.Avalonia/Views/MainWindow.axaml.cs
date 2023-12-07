using Avalonia.Controls;

namespace LeagueSpectator.Avalonia.Views;

public partial class MainWindow : Window, IMainWindow
{
    public nint Handle => TryGetPlatformHandle().Handle;
    public MainWindow()
    {
        InitializeComponent();
    }
}
