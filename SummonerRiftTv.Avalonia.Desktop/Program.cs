using Avalonia;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using SummonerRiftTv.Avalonia.Views;
using SummonerRiftTv.MVVM;
using SummonerRiftTv.MVVM.Helpers;
using SummonerRiftTv.MVVM.IServices;
using SummonerRiftTv.MVVM.IViews;
using System;

namespace SummonerRiftTv.Avalonia.Desktop
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
