using Microsoft.Extensions.DependencyInjection;
using SummonerRiftTv.MVVM.IServices;
using SummonerRiftTv.MVVM.IViewModels;
using SummonerRiftTv.MVVM.Services;
using SummonerRiftTv.MVVM.ViewModels;
using SummonerRiftTv.RiotApi.IServices;
using SummonerRiftTv.RiotApi.Services;

namespace SummonerRiftTv.MVVM
{
    public static class Bootstraper
    {
        public static IServiceCollection BootstrapRequiredServices(this IServiceCollection services)
        {
            return services.AddSingleton<IRiotApiService, RiotApiService>()
                .AddSingleton<IAppDataService, AppDataService>()
                .AddSingleton<IFrozenDataService, FrozenDataService>()
                .AddSingleton<IMainWindowViewModel, MainWindowViewModel>()
                .AddSingleton<IMainWindowService, MainWindowService>();
        }
    }
}
