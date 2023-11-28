using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using LeagueSpectator.IServices;
using LeagueSpectator.MVVM.Extensions;
using LeagueSpectator.MVVM.IServices;
using LeagueSpectator.MVVM.Models;
using LeagueSpectator.Views;
using Material.Styles.Themes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace LeagueSpectator
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
            m_AppDataService.OnLanguageChanged += OnLanguageChanged;
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                Resources.Add(LOCALIZATION_STRINGS_NAME, m_LocalizationStringsService);
                m_MainWindow = Program.ServiceProvider.GetRequiredService<IMainWindow>();
                desktop.MainWindow = (MainWindow)m_MainWindow;
            }

            OnThemeChanged(m_AppDataService.AppData.ThemeType);
            OnLanguageChanged(m_AppDataService.AppData.Language);

            m_AppDataService.OnThemeChanged += OnThemeChanged;

            base.OnFrameworkInitializationCompleted();
        }

        private void OnLanguageChanged(Language obj)
        {
            m_LocalizationStringsService.SetCultureInfo(obj.GetCulture());
        }

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const int SW_HIDE = 0;
        private const int SW_NORMAL = 1;
        private const int SW_SHOWNA = 8;

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(nint hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(nint hWnd, int nCmdShow);
        public static bool UseImmersiveDarkMode(nint handle, bool enabled)
        {
            if (IsWindows10OrGreater(17763))
            {
                int attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (IsWindows10OrGreater(18985))
                {
                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                int useImmersiveDarkMode = enabled ? 1 : 0;
                bool result = DwmSetWindowAttribute(handle, attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
                if (result)
                {
                    ShowWindow(handle, SW_HIDE);
                    Thread.Sleep(10);
                    ShowWindow(handle, SW_SHOWNA);
                }
                return result;
            }

            return false;
        }

        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }
        private void OnThemeChanged(ThemeType theme)
        {
            switch (theme)
            {
                case ThemeType.Default:
                    new PaletteHelper().SetTheme(Theme.Create(Theme.Light, Colors.Teal, Colors.Teal));
                    UseImmersiveDarkMode(m_MainWindow.Handle, false);
                    break;
                case ThemeType.Light:
                    new PaletteHelper().SetTheme(Theme.Create(Theme.Light, Colors.Teal, Colors.Teal));
                    UseImmersiveDarkMode(m_MainWindow.Handle, false);
                    break;
                case ThemeType.Dark:
                    new PaletteHelper().SetTheme(Theme.Create(Theme.Dark, Colors.Teal, Colors.Teal));
                    UseImmersiveDarkMode(m_MainWindow.Handle, true);
                    break;
                default:
                    new PaletteHelper().SetTheme(Theme.Create(Theme.Light, Colors.Teal, Colors.Teal));
                    UseImmersiveDarkMode(m_MainWindow.Handle, false);
                    break;
            }
        }
    }
}
