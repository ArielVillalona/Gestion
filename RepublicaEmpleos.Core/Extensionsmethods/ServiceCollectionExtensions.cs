using Microsoft.Extensions.DependencyInjection;

namespace RepublicaEmpleos.Core.Extensionsmethods
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomContext(this IServiceCollection services)
        {
            return services;
        }
        public static IServiceCollection AddCustomRazonPage(this IServiceCollection services)
        {
            return services;
        }
    }
}
