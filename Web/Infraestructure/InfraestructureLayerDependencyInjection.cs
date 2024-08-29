using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UCR.ECCI.IS.ExampleProject.Domain.Users.Repositories;
using UCR.ECCI.IS.ExampleProject.Infraestructure.Users.Repositories;

namespace UCR.ECCI.IS.ExampleProject.Infraestructure;

public static class InfraestructureLayerDependencyInjection
{
    public static IServiceCollection AddInfraestructureLayerServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IUserRepository, SqlUserRepository>();
        services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}

