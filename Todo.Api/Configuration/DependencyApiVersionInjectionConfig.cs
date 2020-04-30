using Microsoft.Extensions.DependencyInjection;

namespace Todo.Api.Configuration
{
    public static class DependencyApiVersionInjectionConfig
    {
        public static IServiceCollection AddApiVersion(this IServiceCollection services)
        {
            services.AddApiVersioning();
            services.AddVersionedApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'VVV";
                opt.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}