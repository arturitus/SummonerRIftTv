using Avalonia;
using Avalonia.ReactiveUI;
using LeagueSpectator.IServices;
using LeagueSpectator.MVVM;
using LeagueSpectator.MVVM.Helpers;
using LeagueSpectator.MVVM.IServices;
using LeagueSpectator.Views;
using Microsoft.Extensions.DependencyInjection;
using Splat;
using System;

namespace LeagueSpectator
{
    internal class Program
    {
        public static IServiceProvider ServiceProvider { get; }
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.

        static Program()
        {
            ServiceProvider = InitServices();
            LeagueAssetResolver.InitCache(ServiceProvider.GetRequiredService<IFrozenDataService>());
        }

        [STAThread]
        public static void Main(string[] args)
        {
            //BuildServices();
            BuildAvaloniaApp(ServiceProvider).StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        //public static AppBuilder BuildAvaloniaApp(IServiceProvider serviceProvider)
        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure(() => (App)Locator.Current.GetService<IApp>()).UsePlatformDetect()
            .WithInterFont().LogToTrace().UseReactiveUI();
        }

        public static AppBuilder BuildAvaloniaApp(IServiceProvider serviceProvider)
        {
            return AppBuilder.Configure(() => (App)serviceProvider.GetRequiredService<IApp>()).UsePlatformDetect()
            .WithInterFont().LogToTrace().UseReactiveUI();
        }


        private static void BuildServices()
        {
            //Locator.CurrentMutable.RegisterLazySingleton<IMainWindow>(() => new MainWindow());

            //Locator.CurrentMutable.RegisterLazySingleton<ILocalizationStringsService>(() => new LocalizationStringsService());
            //Locator.CurrentMutable.RegisterLazySingleton<IAppDataService>(() => new AppDataService());
            //Locator.CurrentMutable.RegisterLazySingleton<IApp>(() =>
            //{
            //    ILocalizationStringsService localizationStringsService = Locator.Current.GetService<ILocalizationStringsService>();
            //    IAppDataService appDataService = Locator.Current.GetService<IAppDataService>();
            //    //IMainWindow mainWindow = Locator.Current.GetService<IMainWindow>();
            //    return new App(localizationStringsService, appDataService);
            //    //return new App(localizationStringsService, appDataService, mainWindow);
            //});
            //Locator.CurrentMutable.RegisterLazySingleton<IRiotApiService>(() => new RiotApiService());
            //Locator.CurrentMutable.RegisterLazySingleton<IFrozenDataService>(() => new FrozenDataService());
            //Locator.CurrentMutable.RegisterLazySingleton<IMainWindowService>(() => new MainWindowService());
            //Locator.CurrentMutable.RegisterLazySingleton<IMainWindowViewModel>(() =>
            //{
            //    IAppDataService appDataService = Locator.Current.GetService<IAppDataService>();
            //    IMainWindowService mainWindowService = Locator.Current.GetService<IMainWindowService>();
            //    return new MainWindowViewModel(appDataService, mainWindowService);
            //});

            //Locator.CurrentMutable.RegisterLazySingleton<IMainWindow>(() =>
            //{
            //    IMainWindowViewModel mainWindowViewModel = Locator.Current.GetService<IMainWindowViewModel>();
            //    return new MainWindow(mainWindowViewModel);
            //});
        }

        private static ServiceProvider InitServices()
        {
            return new ServiceCollection()
                .BootstrapRequiredServices()
                .AddSingleton<IApp, App>()
                .AddSingleton<IMainWindow, MainWindow>()
                .BuildServiceProvider();
        }
    }
}
