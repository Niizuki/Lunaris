using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Lunaris;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLunaris(this IServiceCollection services, params Assembly[] assemblies)
    {
        if (assemblies == null || assemblies.Length == 0)
        {
            assemblies = new[] { Assembly.GetCallingAssembly() };
        }

        var serviceTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => t.GetCustomAttribute<ServiceAttribute>() != null);

        foreach (var type in serviceTypes)
        {
            services.AddTransient(type);
        }

        return services;
    }
}
