using Api.Repository;
using Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api;

public static class ServiceExtensions
{
    public static IServiceCollection AddStartlistServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IEntriesRepository, EntriesRepository>();
        services.AddTransient<IEntriesService, EntriesService>();

        return services;
    }
}