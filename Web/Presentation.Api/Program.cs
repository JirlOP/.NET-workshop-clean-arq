using UCR.ECCI.IS.ExampleProject.Application.Users.Services;
using UCR.ECCI.IS.ExampleProject.Application;
using UCR.ECCI.IS.ExampleProject.Infraestructure;
using UCR.ECCI.IS.ExampleProject.Presentation.Api.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Lifetimes:
// Singleton: A single instance of the service will be created.
// Transient: A new instance will be created every time the service is requested.
// Scoped: An instance is created once per client request (connection).
/*
builder.Services.AddScoped<IUserService, UserService>(); // Presentation cant access directly to the App service
builder.Services.AddScoped<IUserRepository, SqlUserRepository>(); // Presentation cant access directly to the App repository
*/
// rigth way to do it with clean architecture
builder.Services.AddApplicationLayerServices();
builder.Services.AddInfraestructureLayerServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add CORS policy to allow requests from the Blazor WebAssembly app
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply CORS policy
app.UseCors();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// GET: /weatherforecast is the endpoint
app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

// Generate a new endpoint
// GET: /active-users is the endpoint, with the abstract implementation of the IUserService
/* Implemented cleanly in userEndpoints
app.MapGet("/active-users", async (IUserService userService) =>
{
    var activeUsers = await userService.GetActiveUsersAsync();
    return activeUsers;
})
.WithName("GetActiveUsers")
.WithOpenApi();
*/
// Implemented cleanly in userEndpoints

app.RegisterUserEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

// declare program.cs as public because of testing
public partial class Program;
