using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LazyDI;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddSmartDI(this IServiceCollection services, Assembly assembly)
    {
        var types = assembly.GetTypes();

        foreach (var type in types)
        {
            if (type.IsClass && !type.IsAbstract)
            {
                var interfaces = type.GetInterfaces();

                if (typeof(ITransient).IsAssignableFrom(type))
                {
                    RegisterServices(services, type, interfaces, ServiceLifetime.Transient);
                }
                else if (typeof(IScoped).IsAssignableFrom(type))
                {
                    RegisterServices(services, type, interfaces, ServiceLifetime.Scoped);
                }
                else if (typeof(ISingleton).IsAssignableFrom(type))
                {
                    RegisterServices(services, type, interfaces, ServiceLifetime.Singleton);
                }
            }
        }

        return services;
    }
    private static void RegisterServices(IServiceCollection services, Type implementationType, Type[] interfaces, ServiceLifetime lifetime)
    {
        foreach (var @interface in interfaces)
        {
            if (@interface == typeof(ITransient) || @interface == typeof(IScoped) || @interface == typeof(ISingleton))
                continue;

            switch (lifetime)
            {
                case ServiceLifetime.Transient:
                    services.AddTransient(@interface, implementationType);
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped(@interface, implementationType);
                    break;
                case ServiceLifetime.Singleton:
                    services.AddSingleton(@interface, implementationType);
                    break;
            }
        }
    }
}
