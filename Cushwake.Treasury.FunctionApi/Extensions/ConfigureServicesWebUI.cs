using Cushwake.Treasury.Application.Common.Interfaces;
using Cushwake.Treasury.FunctionApi.Services;
using Cushwake.Treasury.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;



namespace Cushwake.Treasury.FunctionApi.Extensions;

public static class ConfigureServicesWebUI
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();


        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();


        return services;
    }
}

