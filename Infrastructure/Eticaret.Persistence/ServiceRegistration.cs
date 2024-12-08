using Eticaret.Application.Abstraction;
using Eticaret.Application.Repositories;
using Eticaret.Application.Repositories.Order;
using Eticaret.Application.Repositories.Product;
using Eticaret.Persistence.Concretes;
using Eticaret.Persistence.Contexts;
using Eticaret.Persistence.Repositories;
using Eticaret.Persistence.Repositories.Customer;
using Eticaret.Persistence.Repositories.Order;
using Eticaret.Persistence.Repositories.Product;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Eticaret.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<EticaretApiDbContext>(options => options.UseNpgsql(
            (string?)Configuration.ConnectionString));

        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<IFileReadRepository, FileReadRepository>();
        services.AddScoped<IFileWriteRepository, FileWriteRepository>();
        services.AddScoped<IInvoiceFileReadRepository, InvoinceFileReadRepository>();
        services.AddScoped<IInvoiceFileWriteRepository, InvoinceFileWriteRepository>();
        services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
        services.AddScoped<IProductIMageFileWriteRepository, ProductImageFileWriteRepository>();

        // services.AddSingleton<IProductService, ProductService>();
    }
}