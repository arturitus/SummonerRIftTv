using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Avalonia.Threading;
using DialogHostAvalonia;
using LeagueSpectator.Avalonia.IViews;
using LeagueSpectator.MVVM.IViewModels;
using LeagueSpectator.MVVM.Models;
using LeagueSpectator.MVVM.ViewModels;
using System.Collections.Frozen;
using System.Threading.Tasks;

namespace LeagueSpectator.Avalonia.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>, IMainWindow
    {
        public nint Handle => TryGetPlatformHandle().Handle;
        public MainWindow()
        {

        }

        public MainWindow(IMainWindowViewModel mainWindowViewModel) //IAppDataService appDataService,
        {
            InitializeComponent();
            DataContext = mainWindowViewModel;
            mainWindowViewModel.IsBusy += ToggleBusyDialog;
            mainWindowViewModel.InfoDialog += InfoDialog;
            mainWindowViewModel.ErrorDialog += ErrorDialog;
            //Position = appDataService.AppData.Position;
            //PositionChanged += MainWindow_PositionChanged;
            //this.WhenActivated(x =>
            //{
            //    appDataService.SetTheme(appDataService.AppData.ThemeType);
            //});
        }

        private void ErrorDialog(ErrorDialogFormat format)
        {
            Dispatcher.UIThread.InvokeAsync(async () =>
            {
                StackPanel itemsControl = (StackPanel)Resources["ErrorDialogPanel"];
                itemsControl.DataContext = format;
                _ = DialogHost.Show(itemsControl, "busyDialog");
                await Task.Delay(5000);
                DialogHost.Close("busyDialog");
            });
        }

        private void InfoDialog(FrozenSet<InfoDialogKeys> set)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                ItemsControl itemsControl = (ItemsControl)Resources["InfoDialogPanel"];
                itemsControl.ItemsSource = set;
                DialogHost.Show(itemsControl, "busyDialog");
            });
        }

        private void ToggleBusyDialog(bool busy)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (DialogHost.IsDialogOpen("busyDialog"))
                {
                    DialogHost.Close("busyDialog");
                    return;
                }
                //StackPanel stackPanel = new StackPanel();
                //stackPanel.Children.Add(new ProgressBar()
                //{
                //    IsIndeterminate = true,
                //    Classes = { "Circle" }, //MaterialCircularProgressBar
                //    Width = 30,
                //    Height = 30,
                //    BorderThickness = new Thickness(30)
                //});
                //DialogHost.Show(stackPanel, "busyDialog");
                DialogHost.Show(Resources["BusyDialogPanel"], "busyDialog");
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
