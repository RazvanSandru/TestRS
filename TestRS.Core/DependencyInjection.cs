using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestRS.Core.Services;

namespace TestRS.Core;
public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        return services;
    }
}
