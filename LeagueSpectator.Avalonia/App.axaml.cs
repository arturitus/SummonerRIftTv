using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using LeagueSpectator.Avalonia.Extensions;
using LeagueSpectator.Avalonia.Views;
using LeagueSpectator.MVVM;
using LeagueSpectator.MVVM.Extensions;
using LeagueSpectator.MVVM.Helpers;
using LeagueSpectator.MVVM.IServices;
using LeagueSpectator.MVVM.IViews;
using LeagueSpectator.MVVM.Models;
using Material.Styles.Themes;
using System.Globalization;

namespace LeagueSpectator.Avalonia
{
    public partial class App : Application, IApp
    {
        private const string LOCALIZATION_STRINGS_NAME = "Strings";
        private IMainWindow m_MainWindow;
        private readonly IAppDataService m_AppDataService;

        public App(IAppDataService appDataService)
        {
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
            //OnLanguageChanged(m_AppDataService.AppData.Language);
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                m_MainWindow = DependencyInjector.GetRequiredService<IMainWindow>();
                desktop.MainWindow = (MainWindow)m_MainWindow;
            }
            m_AppDataService.OnThemeChanged += OnThemeChanged;

            OnThemeChanged(m_AppDataService.AppData.ThemeType);

            AssetLoaderExtensions.Init();
        }

        private void OnLanguageChanged(Language obj)
        {
            string oldLang = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = obj.GetCulture();
            //m_LocalizationStringsService.SetCultureInfo(obj.GetCulture());
            Translate(oldLang, CultureInfo.CurrentCulture.Name);
        }

        public static void Translate(string previousLanguage, string targetLanguage)
        {
            ResourceDictionary r = Current.Resources[previousLanguage] as ResourceDictionary;
            Current.Resources.MergedDictionaries.Remove(r);
            Current.Resources.MergedDictionaries.Add(Current.Resources[targetLanguage] as ResourceDictionary);
        }

        private void OnThemeChanged(ThemeType theme)
        {
            MaterialTheme materialTheme = Current.LocateMaterialTheme<MaterialTheme>();
            switch (theme)
            {
                case ThemeType.Default:
                    materialTheme.CurrentTheme = Theme.Create(Theme.Light, Colors.Teal, Colors.Teal);
                    WindowsAPI.UseImmersiveDarkMode(m_MainWindow.Handle, false);
                    break;
                case ThemeType.Light:
                    materialTheme.CurrentTheme = Theme.Create(Theme.Light, Colors.Teal, Colors.Teal);
                    WindowsAPI.UseImmersiveDarkMode(m_MainWindow.Handle, false);
                    break;
                case ThemeType.Dark:
                    materialTheme.CurrentTheme = Theme.Create(Theme.Dark, Colors.Teal, Colors.Teal);
                    WindowsAPI.UseImmersiveDarkMode(m_MainWindow.Handle, true);
                    break;
                default:
                    materialTheme.CurrentTheme = Theme.Create(Theme.Light, Colors.Teal, Colors.Teal);
                    WindowsAPI.UseImmersiveDarkMode(m_MainWindow.Handle, false);
                    break;
            }
        }
    }
}
