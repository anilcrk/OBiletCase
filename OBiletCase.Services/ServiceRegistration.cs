using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using OBiletCase.ApiClientAdapter.Interfaces;
using OBiletCase.ApiClientAdapter.Services;
using System.Net.Http.Headers;
using OBiletCase.Services.Interfaces;
using OBiletCase.Services.Services;

namespace OBiletCase.Services
{
    /// <summary>
    /// Provides extension methods for IServiceCollection to register and configure services and API clients.
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// Registers and configures the OBilet API client to the given IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to which the OBilet API client will be registered.</param>
        /// <param name="configuration">The application configuration to fetch settings for the API client.</param>
        /// <returns>The same IServiceCollection to allow for method chaining.</returns>
        public static IServiceCollection AddOBiletApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IOBiletApiClient, OBiletApiClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration[Constants.Configuration.HttpClientBaseAddress]);

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", configuration[Constants.Configuration.HttpClientAuthenticationToken]);
                httpClient.DefaultRequestHeaders.Add("user-agent", "OBiletCase Rest Api Client");
                httpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                httpClient.DefaultRequestHeaders.Add("Keep-Alive", "540");
                httpClient.Timeout = TimeSpan.FromSeconds(540);
            });

            return services;
        }

        /// <summary>
        /// Registers service layer dependencies to the IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        public static void AddServiceBindings(this IServiceCollection services)
        {
            services.AddTransient<IBusJourneyService, BusJourneyService>();
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<IBusLocationService, BusLocationService>();
        }
    }
}
