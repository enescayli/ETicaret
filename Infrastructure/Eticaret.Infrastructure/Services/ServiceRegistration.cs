using Eticaret.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IFileService, FileService>();
    }
}