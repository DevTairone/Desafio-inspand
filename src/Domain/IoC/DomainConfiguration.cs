using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Domain.IoC;

public static class DomainConfiguration
{
    public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IUserService, UserService>();

        return services;
    }
}