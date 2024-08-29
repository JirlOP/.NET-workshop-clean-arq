using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using UCR.ECCI.IS.ExampleProject.Domain.Users.Repositories;
using UCR.ECCI.IS.ExampleProject.Infraestructure.ApiClient.Users.Repositories;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient;

namespace UCR.ECCI.IS.ExampleProject.Infraestructure.ApiClient;


// Extension method used to add services to the DI container
public static class InfrastructureApiClientLayerDependencyInjection
{
    public static IServiceCollection AddInfrastructureApiClientLayerServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Step 1: Configure authentication for the ApiClient.
        services.AddScoped<IAuthenticationProvider, AnonymousAuthenticationProvider>();
        // Step 2: Configure the request adapter.
        services.AddScoped<IRequestAdapter, HttpClientRequestAdapter>(serviceProvider =>
        {
            var adapter = new HttpClientRequestAdapter(
                serviceProvider.GetRequiredService<IAuthenticationProvider>(),
                httpClient: serviceProvider.GetRequiredService<HttpClient>());

            // Step 3: Define the base URL.
            adapter.BaseUrl = configuration["DownstreamApi:BaseUrl"];

            return adapter;
        });
        // Step 4: Register the ApiClient.
        services.AddScoped<ApiClientKiota>();
        services.AddScoped<IUserRepository, ApiClientUserRepository>();

        return services;
    }
}



