using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Infra.Context;

namespace Todo.Api.Configuration
{
    public static class DependencyRepositoryInjectionConfig
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    assembly => assembly.MigrationsAssembly(typeof(Startup).Assembly.FullName));
            });

            services.AddScoped<TodoDbContext, TodoDbContext>();

            return services;
        }
    }
}