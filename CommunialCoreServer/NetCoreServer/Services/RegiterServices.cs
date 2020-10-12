using Microsoft.Extensions.DependencyInjection;

namespace NetCoreServer.Services
{
    public static class RegiterServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOfficeService, OfficeService>();

            return services;
        }
    }
}