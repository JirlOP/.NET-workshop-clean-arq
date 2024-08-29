using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UCR.ECCI.IS.ExampleProject.Presentation.Blazor;
using UCR.ECCI.IS.ExampleProject.Application;
// we can do Infrastrcuture reference because we do a project that extend references for this layer 
using UCR.ECCI.IS.ExampleProject.Infraestructure.ApiClient;

// Top level statements are a new feature in C# 9.0
// It is alike to the Main method, but without the Main method
// Like python conf script
// This is the entry point of the application
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Step 0: Configure the HttpClient.
// HttpClient is a class that allows you to send HTTP requests and receive HTTP responses from a resource identified by a URI.
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// The Rest of the Steps are in the Infrastructure Layer now, where the ApiClient is implemented
// because is the building of the ApiClient
// Is in Infraestructure.ApiClient/InfrastructureApiClientLayerDependencyInjection.cs

/*
 * These lines means:
 * Add the IUserRepository implementation to the service collection with ApiClientUserRepository as the implementation.
 * Add the IUserService implementation to the service collection with UserService as the implementation.
 */
// builder.Services.AddScoped<IUserRepository, ApiClientUserRepository>();
// builder.Services.AddScoped<IUserService, UserService>();
// rigth way to do it with clean architecture
// we add services from the Application Layer and the Infrastructure Layer to the service collection, services implemented for us.
builder.Services.AddApplicationLayerServices();
builder.Services.AddInfrastructureApiClientLayerServices(builder.Configuration);


await builder.Build().RunAsync();
