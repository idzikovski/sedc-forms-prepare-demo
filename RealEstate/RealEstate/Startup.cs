using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealEstate.Interfaces;
using RealEstate.Services;

namespace RealEstate
{
    public class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static void Init()
        {
            var host = CreateDefaultBuilder().ConfigureServices(ConfigureServices).Build();
            ServiceProvider = host.Services;
        }

        private static IHostBuilder CreateDefaultBuilder()
        {
            var builder = new HostBuilder();

            return builder;
        }

        private static void ConfigureServices(HostBuilderContext ctx, IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IEstatesService, EstatesService>();
            serviceCollection.AddSingleton<IRestClientService, RestClientService>();
            serviceCollection.AddSingleton<IPlatformService, PlatformService>();
            serviceCollection.AddSingleton<INavigationService, NavigationService>();
        }
    }
}
