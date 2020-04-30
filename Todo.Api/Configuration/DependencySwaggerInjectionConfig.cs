using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Todo.Api.Configuration
{
    public static class DependencySwaggerInjectionConfig
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var item in provider.ApiVersionDescriptions)
                {
                    c.SwaggerDoc(item.GroupName, new OpenApiInfo
                    {
                        Title = $"Todo Api {item.ApiVersion}",
                        Version = item.ApiVersion.ToString(),
                        Description =
                            "Todo Rest Api dotnet 3.1 para consulta de instenções de tarefas.",
                        Contact = new OpenApiContact
                        {
                            Name = "Todo"
                        }
                    });
                }
            });

            return services;
        }
    }
}