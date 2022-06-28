using Microsoft.Extensions.DependencyInjection;
using Mpaille.BestBuyInventoryFinder.Domain;
using Mpaille.BestBuyInventoryFinder.Domain.Services;

namespace Mpaille.BestBuyInventoryFinder.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, ApplicationSettings applicationSettings)
        {
            services.AddSingleton(applicationSettings);

            services.AddHttpClient<IBestBuyAvailabilityService, BestBuyAvailabilityService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(applicationSettings.BestBuyApiBaseAddress);
            });
        }
    }
}
