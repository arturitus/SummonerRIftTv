using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using LeagueSpectator.Avalonia.Assets;
using LeagueSpectator.Avalonia.ViewModels;
using LeagueSpectator.Avalonia.Views;
using LeagueSpectator.MVVM.Services;
using System.Globalization;

namespace LeagueSpectator.Avalonia
{
    public partial class App : Application, IApp
    {
        private const string LOCALIZATION_STRINGS_NAME = "Strings";
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            Strings.Culture = new CultureInfo("es-ES");
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                Resources.Add(LOCALIZATION_STRINGS_NAME, new LocalizationStringsService());
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainViewModel()
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = new MainViewModel()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
