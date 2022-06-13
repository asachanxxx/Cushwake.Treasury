using Cushwake.Treasury.Application.Common.Interfaces;
using Cushwake.Treasury.Infrastructure.Files;
using Cushwake.Treasury.Infrastructure.Identity;
using Cushwake.Treasury.Infrastructure.Persistence;
using Cushwake.Treasury.Infrastructure.Persistence.Interceptors;
using Cushwake.Treasury.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;




namespace Cushwake.Treasury.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        bool useMemory = bool.Parse(Environment.GetEnvironmentVariable("key01")!);

        if (useMemory)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("SrcDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                          options.UseSqlServer(
                              Environment.GetEnvironmentVariable("ConnectionString") ?? throw new InvalidOperationException(),
                              b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)), ServiceLifetime.Transient);

        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        //services
        //    .AddDefaultIdentity<ApplicationUser>()
        //    .AddRoles<IdentityRole>()
        //    .AddEntityFrameworkStores<ApplicationDbContext>();

        //services.AddIdentityServer()
        //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

        //services.AddAuthentication()
        //    .AddIdentityServerJwt();

        //services.AddAuthorization(options =>
        //    options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        return services;
    }
}
