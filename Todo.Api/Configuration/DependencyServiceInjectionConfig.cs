using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Api.Services;
using Todo.Domain.Services;
using Todo.Domain.UserContext.Repositories;
using Todo.Infra.Context;
using Todo.Infra.Repositories;

namespace Todo.Api.Configuration
{
    public static class DependencyServiceInjectionConfig
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }
}