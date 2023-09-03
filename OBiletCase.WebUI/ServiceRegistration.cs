using OBiletCase.WebUI.ModelServices;

namespace OBiletCase.WebUI
{
    /// <summary>
    /// The Class for defining Dependency Bindings
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// This method adds ModelService dependency Injection bindings to Dependency Inversion Container
        /// </summary>
        /// <param name="services"></param>
        public static void AddModelServices(this IServiceCollection services)
        {
            services.AddTransient<BusLocationModelService>();
            services.AddTransient<SessionModelService>();
        }
    }
}
