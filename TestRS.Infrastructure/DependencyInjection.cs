using Microsoft.Extensions.DependencyInjection;
using TestRS.Core.Repositories;
using TestRS.Core.Services;
using TestRS.Infrastructure.Context;
using TestRS.Infrastructure.Repositories;
using TestRS.Infrastructure.Services;

namespace TestRS.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IArchiveRepository, ArchiveRepository>();
        services.AddScoped<IArchiverService, ArchiverService>();
        services.AddSingleton<DapperContext>();

        return services;
    }
}
