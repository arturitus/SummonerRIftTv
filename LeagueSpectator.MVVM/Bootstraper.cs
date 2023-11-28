using LeagueSpectator.MVVM.IServices;
using LeagueSpectator.MVVM.IViewModels;
using LeagueSpectator.MVVM.Services;
using LeagueSpectator.RiotApi.IServices;
using LeagueSpectator.RiotApi.Services;
using LeagueSpectator.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueSpectator.MVVM
{
    public static class Bootstraper
    {
        public static IServiceCollection BootstrapRequiredServices(this IServiceCollection services)
        {
            return services.AddSingleton<IRiotApiService, RiotApiService>()
                .AddSingleton<IAppDataService, AppDataService>()
                .AddSingleton<ILocalizationStringsService, LocalizationStringsService>()
                .AddSingleton<IFrozenDataService, FrozenDataService>()
                .AddSingleton<IMainWindowViewModel, MainWindowViewModel>()
                .AddSingleton<IMainWindowService, MainWindowService>();
        }
    }
}
