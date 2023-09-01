using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBiletCase.ApiClientAdapter.Interfaces;
using OBiletCase.ApiClientAdapter.Services;
using System.Net.Http.Headers;
using OBiletCase.Services.Interfaces;
using OBiletCase.Services.Services;

namespace OBiletCase.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddOBiletApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IOBiletApiClient, OBiletApiClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration[Constants.Configuration.HttpClientBaseAddress]);

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("user-agent", "OBiletCase Rest Api Client");
                httpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                httpClient.DefaultRequestHeaders.Add("Keep-Alive", "540");
                httpClient.Timeout = TimeSpan.FromSeconds(540);
            });

            return services;
        }

        public static void AddServiceBindings(this IServiceCollection services)
        {
            services.AddTransient<IBusLocationService, BusLocationService>();
        }
    }
}
