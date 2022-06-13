
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text;
using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Settings;
using Microsoft.OpenApi;
using Microsoft.Extensions.DependencyInjection;

namespace Cushwake.Treasury.FunctionApi.Extensions;

public static class SwashBuckleExtention
{
    public static void AddSwashBuckle(this IFunctionsHostBuilder builder)
    {
        builder.AddSwashBuckle(Assembly.GetExecutingAssembly(),
            swaggerDocOptions =>
            {
                swaggerDocOptions.SpecVersion = OpenApiSpecVersion.OpenApi3_0;
                swaggerDocOptions.AddCodeParameter = true;
                swaggerDocOptions.PrependOperationWithRoutePrefix = true;
                swaggerDocOptions.XmlPath = "TestFunction.xml";
                swaggerDocOptions.Documents = new[]
                {
                    new SwaggerDocument
                    {
                        Name = "v1",
                        Title = "BudgetTracker",
                        Description = "BudgetTracker APIs",
                        Version = "v1"
                    }
                };
                swaggerDocOptions.Title = "BudgetTracker";

                swaggerDocOptions.ConfigureSwaggerGen = x =>
                {
                    x.CustomOperationIds(apiDesc => apiDesc.TryGetMethodInfo(out var methodInfo)
                        ? methodInfo.Name
                        : new Guid().ToString());
                };
            });
    }
}

