using CFPkHex.Backend.Repository;

namespace CFPkHex.Backend.Services
{
    public static class ScopedServices
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<BuilderRepository>();

            return services;
        }
    }
}
