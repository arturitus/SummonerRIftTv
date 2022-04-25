using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using LeagueSpectator.Services;
using LeagueSpectator.ViewModels;
using LeagueSpectator.Views;
using Splat;

namespace LeagueSpectator
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public App()
        {
            BuildServices();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
        private void BuildServices()
        {
            Locator.CurrentMutable.RegisterLazySingleton<IMainWindowService>(() => new MainWindowService());
            Locator.CurrentMutable.RegisterLazySingleton<IRiotApiService>(() => new RiotApiService());
        }
    }
}
