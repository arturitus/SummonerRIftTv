using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using LeagueSpectator.Avalonia.IViews;
using LeagueSpectator.Avalonia.Views;
using LeagueSpectator.MVVM.Extensions;
using LeagueSpectator.MVVM.Helpers;
using LeagueSpectator.MVVM.IServices;
using LeagueSpectator.MVVM.Models;
using Material.Styles.Themes;

namespace LeagueSpectator.Avalonia
{
    public partial class App : Application, IApp
    {
        private const string LOCALIZATION_STRINGS_NAME = "Strings";
        private IMainWindow m_MainWindow;
        private readonly ILocalizationStringsService m_LocalizationStringsService;
        private readonly IAppDataService m_AppDataService;

        public App(ILocalizationStringsService localizationStringsService, IAppDataService appDataService)
        {
            m_LocalizationStringsService = localizationStringsService;
            m_AppDataService = appDataService;
        }

        public App()
        {

        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            base.OnFrameworkInitializationCompleted();

            m_AppDataService.OnLanguageChanged += OnLanguageChanged;

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                Resources.Add(LOCALIZATION_STRINGS_NAME, m_LocalizationStringsService);
                m_MainWindow = DependencyInjector.GetRequiredService<IMainWindow>();
                desktop.MainWindow = (MainWindow)m_MainWindow;
            }

            OnLanguageChanged(m_AppDataService.AppData.Language);

            m_AppDataService.OnThemeChanged += OnThemeChanged;

            OnThemeChanged(m_AppDataService.AppData.ThemeType);

        }

        private void OnLanguageChanged(Language obj)
        {
            m_LocalizationStringsService.SetCultureInfo(obj.GetCulture());
        }

        private void OnThemeChanged(ThemeType theme)
        {
            switch (theme)
            {
                case ThemeType.Default:
                    new PaletteHelper().SetTheme(Theme.Create(Theme.Light, Colors.Teal, Colors.Teal));
                    WindowsAPI.UseImmersiveDarkMode(m_MainWindow.Handle, false);
                    break;
                case ThemeType.Light:
                    new PaletteHelper().SetTheme(Theme.Create(Theme.Light, Colors.Teal, Colors.Teal));
                    WindowsAPI.UseImmersiveDarkMode(m_MainWindow.Handle, false);
                    break;
                case ThemeType.Dark:
                    new PaletteHelper().SetTheme(Theme.Create(Theme.Dark, Colors.Teal, Colors.Teal));
                    WindowsAPI.UseImmersiveDarkMode(m_MainWindow.Handle, true);
                    break;
                default:
                    new PaletteHelper().SetTheme(Theme.Create(Theme.Light, Colors.Teal, Colors.Teal));
                    WindowsAPI.UseImmersiveDarkMode(m_MainWindow.Handle, false);
                    break;
            }
        }
    }
}
