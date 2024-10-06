using Eticaret.Application.Abstraction;
using Eticaret.Persistence.Concretes;
using Eticaret.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Eticaret.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<EticaretApiDbContext>(options =>
            options.UseNpgsql(
                 (string?)Configuration.ConnectionString
            )); 
        // services.AddSingleton<IProductService, ProductService>();
    }
}