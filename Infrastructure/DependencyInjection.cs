using Domain.Interfaces;
using Infrastructure.EntityFramework;
using Infrastructure.Extensions;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration conf)
    {
        services.ThrowIfNull();
        conf.ThrowIfNull();
        var contextOptions = new DbContextOptionsBuilder<Context>()
            .UseNpgsql("Host=localhost;Port=5432;Username=myp;Password=batata123;Database=store;")
            .Options;

        
        // services.AddDbContext<Context>();
        
        
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IBookRepository, BookRepository>();
        services.AddTransient<IAuthorRepository, AuthorRepository>();
        
        
        
        
        services.AddTransient(_ => new Context(contextOptions));

    }
}