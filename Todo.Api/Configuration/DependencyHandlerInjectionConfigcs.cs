using Microsoft.Extensions.DependencyInjection;
using Todo.Domain.TodoContext.Handler;
using Todo.Domain.UserContext.Handler;

namespace Todo.Api.Configuration
{
    public static class DependencyHandlerInjectionConfig
    {
        public static IServiceCollection AddHandler(this IServiceCollection services)
        {
            services.AddTransient<UserHandler, UserHandler>();
            services.AddTransient<TodoHandler, TodoHandler>();

            return services;
        }
    }
}