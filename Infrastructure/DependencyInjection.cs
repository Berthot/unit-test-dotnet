using Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration conf)
    {
        services.ThrowIfNull();
        conf.ThrowIfNull();
    }
}