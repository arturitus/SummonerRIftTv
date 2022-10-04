using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Win32;
using LeagueSpectator.Models;
using LeagueSpectator.Services;
using Splat;

namespace LeagueSpectator.Views
{
    public partial class MainWindow : Window
    {
        AppData appData;
        public MainWindow()
        {
            InitializeComponent();
            IMainWindowService mainWindowService = Locator.Current.GetService<IMainWindowService>();
            appData = new AppData();
            mainWindowService.GetAppData(ref appData);
            Position = appData.Position;
            PositionChanged += MainWindow_PositionChanged;
        }

        private void MainWindow_PositionChanged(object? sender, PixelPointEventArgs e)
        {
            if (WindowState == WindowState.Normal && e.Point.X > 0 && e.Point.Y > 0)
            {
                appData.Position = e.Point;
            }
        }
    }
}
