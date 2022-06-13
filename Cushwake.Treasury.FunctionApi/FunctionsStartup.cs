using Cushwake.Treasury.FunctionApi.Extensions;
using Cushwake.Treasury.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;


[assembly: FunctionsStartup(typeof(MyNamespace.Startup))]
namespace MyNamespace;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        //Injecting required Services
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices();
        builder.Services.AddWebUIServices();

        builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //builder.Services.AddSingleton(c => new ContextUser(new HttpContextAccessor(), ctxUser));
        builder.AddSwashBuckle();
    }
}
