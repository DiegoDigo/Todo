using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Todo.Domain.UserContext.Command.Input;
using Todo.Domain.UserContext.Command.Output;
using Todo.Domain.UserContext.Entities;
using Todo.Shared.ValuesObjects;

namespace Todo.Api.Configuration
{
    public static class DependencyAutoMapperInjectionConfig
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<CreateNewUserCommand, User>()
                    .ForMember(dest => dest.Password,
                        opt => opt.MapFrom(src => src.Password))
                    .ForMember(dest => dest.Email,
                        opt => opt.MapFrom(src => new Email(src.Email)));

                config.CreateMap<User, CreateNewUserResponse>()
                    .ForMember(dest => dest.Id,
                        opt => opt.MapFrom(src => src.Id.ToString()))
                    .ForMember(dest => dest.Email,
                        opt => opt.MapFrom(src => src.Email.Address));
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}