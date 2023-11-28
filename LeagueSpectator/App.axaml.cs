using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using LeagueSpectator.Helpers;
using LeagueSpectator.IServices;
using LeagueSpectator.IViewModels;
using LeagueSpectator.Models;
using LeagueSpectator.RiotApi.IServices;
using LeagueSpectator.RiotApi.Services;
using LeagueSpectator.Services;
using LeagueSpectator.ViewModels;
using LeagueSpectator.Views;
using Material.Styles.Themes;
using Splat;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace LeagueSpectator
{
    public partial class App : Application
    {
        private IMainWindow m_MainWindow;
        public static LocalizationStrings LocalizationStrings { get; } = new LocalizationStrings();
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public App()
        {
            BuildServices();
            if (!BitmapHelper.Initialized)
            {
                BitmapHelper.Initialize();
            }
        }

        public override void OnFrameworkInitializationCompleted()
        {
            IAppDataService appService = Locator.Current.GetService<IAppDataService>();
            appService.OnLanguageChanged += OnLanguageChanged;
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                Resources.Add("Strings", LocalizationStrings);
                m_MainWindow = Locator.Current.GetService<IMainWindow>();
                desktop.MainWindow = (MainWindow)m_MainWindow;
            }

            OnThemeChanged(appService.AppData.ThemeType);
            OnLanguageChanged(appService.AppData.Language);

            appService.OnThemeChanged += OnThemeChanged;

            base.OnFrameworkInitializationCompleted();
        }

        private void OnLanguageChanged(Language obj)
        {
            LocalizationStrings.SetCultureInfo(obj.GetCulture());
        }

        private void BuildServices()
        {
            Locator.CurrentMutable.RegisterLazySingleton<IAppDataService>(() => new AppDataService());
            Locator.CurrentMutable.RegisterLazySingleton<IRiotApiService>(() => new RiotApiService());
            Locator.CurrentMutable.RegisterLazySingleton<IFrozenDataService>(() => new FrozenDataService());
            Locator.CurrentMutable.RegisterLazySingleton<IMainWindowViewModel>(() =>
            {
                IAppDataService appDataService = Locator.Current.GetService<IAppDataService>();
                return new MainWindowViewModel(appDataService);
            });

            Locator.CurrentMutable.RegisterLazySingleton<IMainWindow>(() =>
            {
                IMainWindowViewModel mainWindowViewModel = Locator.Current.GetService<IMainWindowViewModel>();
                return new MainWindow(mainWindowViewModel);
            });

            Locator.CurrentMutable.RegisterLazySingleton<IMainWindowService>(() => new MainWindowService());

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
