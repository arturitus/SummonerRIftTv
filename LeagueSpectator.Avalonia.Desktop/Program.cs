using Avalonia;
using Avalonia.ReactiveUI;
using LeagueSpectator.Avalonia.Views;
using LeagueSpectator.MVVM;
using LeagueSpectator.MVVM.Helpers;
using LeagueSpectator.MVVM.IServices;
using LeagueSpectator.MVVM.IViews;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LeagueSpectator.Avalonia.Desktop
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.

        [STAThread]
        public static void Main(string[] args)
        {
            BuildServices();
            LeagueAssetResolver.InitCache(DependencyInjector.GetRequiredService<IFrozenDataService>());
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure(() => (App)DependencyInjector.GetRequiredService<IApp>()).UsePlatformDetect()
            .WithInterFont().LogToTrace().UseReactiveUI();
        }

        private static void BuildServices()
        {
            new ServiceCollection()
                .BootstrapRequiredServices()
                .AddSingleton<IApp, App>()
                .AddSingleton<IMainWindow, MainWindow>()
                .InitDependencyInjector();
        }
    }
}
