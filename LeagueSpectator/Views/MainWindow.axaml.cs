using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using LeagueSpectator.IServices;
using LeagueSpectator.MVVM.IViewModels;

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
            appDataService.IsBusy += ToggleBusyDialog;
            //Position = appDataService.AppData.Position;
            //PositionChanged += MainWindow_PositionChanged;
        }

        private void ToggleBusyDialog(bool busy)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (DialogHost.DialogHost.IsDialogOpen("busyDialog"))
                {
                    DialogHost.DialogHost.Close("busyDialog");
                    return;
                }
                StackPanel stackPanel = new StackPanel();
                stackPanel.Children.Add(new ProgressBar()
                {
                    IsIndeterminate = true,
                    Classes = new Classes("Circle"),
                    Width = 30,
                    Height = 30,
                    BorderThickness = new Thickness(30)
                });
                DialogHost.DialogHost.Show(stackPanel);
            });
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
