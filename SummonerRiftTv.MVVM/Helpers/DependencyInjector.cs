using Microsoft.Extensions.DependencyInjection;

namespace SummonerRiftTv.MVVM.Helpers
{
    public static class DependencyInjector
    {
        private static ServiceProvider m_ServiceProvider;
        //public static ServiceCollection ServicesCollection { get; private set; }

        //public void RegisterSingleton<T>() where T : class
        //{
        //    ServiceProvider = ServicesCollection.AddSingleton<T>().BuildServiceProvider();
        //}

        //public void RegisterSingleton<T, TImpl>() where T : class where TImpl : class, T
        //{
        //    ServiceProvider = ServicesCollection.AddSingleton<T, TImpl>().BuildServiceProvider();
        //}

        //public void RegisterSingleton<T>(Func<IServiceProvider, T> func) where T : class
        //{
        //    ServiceProvider = ServicesCollection.AddSingleton(func).BuildServiceProvider();
        //}

        //public void RegisterSingleton<T, TImpl>(Func<IServiceProvider, TImpl> func) where T : class where TImpl : class, T
        //{
        //    ServiceProvider = ServicesCollection.AddSingleton<T, TImpl>(func).BuildServiceProvider();
        //}

        //public void RegisterTransient<T>() where T : class
        //{
        //    ServicesCollection.AddTransient<T>();
        //}

        //public void RegisterTransient<T, TImpl>() where T : class where TImpl : class, T
        //{
        //    ServiceProvider = ServicesCollection.AddTransient<T, TImpl>().BuildServiceProvider();
        //}

        //public void RegisterTransient<T>(Func<IServiceProvider, T> func) where T : class
        //{
        //    ServiceProvider = ServicesCollection.AddTransient(func).BuildServiceProvider();
        //}

        //public T GetService<T>() where T : class
        //{
        //    return ServiceProvider?.GetService<T>();
        //}
        //public IEnumerable<T> GetServices<T>() where T : class
        //{
        //    return ServiceProvider?.GetServices<T>();
        //}

        public static T GetRequiredService<T>() where T : class
        {
            return m_ServiceProvider.GetRequiredService<T>();
        }

        public static void InitDependencyInjector(this IServiceCollection serviceCollection)
        {
            m_ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        //public static object GetRequiredService(Type type)
        //{
        //    IEnumerable<object> asdt = serviceProvider.GetServices(type);
        //    return serviceProvider?.GetRequiredService(type)!;
        //}
    }
}
