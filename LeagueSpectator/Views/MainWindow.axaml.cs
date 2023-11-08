using Avalonia.Controls;
using LeagueSpectator.IServices;
using LeagueSpectator.IViewModels;

namespace LeagueSpectator.Views
{
    public partial class MainWindow : Window, IMainWindow
    {
        public nint Handle => PlatformImpl.Handle.Handle;
        public MainWindow()
        {

        }

        public MainWindow(IMainWindowViewModel appDataService)
        {
            InitializeComponent();
            DataContext = appDataService;
            //Position = appDataService.AppData.Position;
            //PositionChanged += MainWindow_PositionChanged;
        }

        //private void MainWindow_PositionChanged(object? sender, PixelPointEventArgs e)
        //{
        //    if (WindowState == WindowState.Normal && e.Point.X > 0 && e.Point.Y > 0)
        //    {
        //        m_IAppDataService.AppData.Position = e.Point;
        //    }
        //}
    }
}
