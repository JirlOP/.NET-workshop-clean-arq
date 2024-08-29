using Microsoft.Extensions.DependencyInjection;
using UCR.ECCI.IS.ExampleProject.Application.Users.Services;

namespace UCR.ECCI.IS.ExampleProject.Application;

// Extension method used to add services to the DI container
public static class ApplicationLayerDependencyInjection
{
    /*
     * ApplicationLayerDependencyInjection.AddApplicationLayerServices(services);
     * services.AddApplicationLayerServices();
     */
    public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
