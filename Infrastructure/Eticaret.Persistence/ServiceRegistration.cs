using Eticaret.Application.Abstraction;
using Eticaret.Persistence.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace Eticaret.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddSingleton<IProductService, ProductService>();
    }
}