using Microsoft.Extensions.DependencyInjection;

namespace SummonerRiftTv.MVVM.Helpers
{
    public static class DependencyInjector
    {
        private static ServiceProvider? m_ServiceProvider;

        public static T? GetRequiredService<T>() where T : class
        {
            return m_ServiceProvider?.GetRequiredService<T>();
        }

        public static void InitDependencyInjector(this IServiceCollection serviceCollection)
        {
            m_ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
