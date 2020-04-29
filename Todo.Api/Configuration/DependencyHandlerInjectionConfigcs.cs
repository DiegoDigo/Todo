using Microsoft.Extensions.DependencyInjection;
using Todo.Domain.UserContext.Handler;

namespace Todo.Api.Configuration
{
    public static class DependencyHandlerInjectionConfig
    {
        public static IServiceCollection AddHandler(this IServiceCollection services)
        {
            services.AddTransient<UserHandler, UserHandler>();

            return services;
        }
    }
}