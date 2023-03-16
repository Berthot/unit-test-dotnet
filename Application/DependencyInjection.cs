using Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void RegisterApplication(this IServiceCollection services, IConfiguration conf)
    {
        services.ThrowIfNull();
        conf.ThrowIfNull();

    }
}