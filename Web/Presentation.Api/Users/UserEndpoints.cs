using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.IS.ExampleProject.Application.Users.Services;
using UCR.ECCI.IS.ExampleProject.Presentation.Api.Users.Mappers;
using UCR.ECCI.IS.ExampleProject.Presentation.Api.Users.Responses;

namespace UCR.ECCI.IS.ExampleProject.Presentation.Api.Users;

/// <summary>
/// Class that contains the endpoints for the User entity 
/// Receives Entities and returns DTOs
/// </summary>
public static class UserEndpoints
{
    /// <summary>
    /// Method that returns the active users(Dtos)
    /// [FromServices] attribute is used to say we want to obtain that 
    /// parameter from the DI service container
    /// </summary>
    /// <remarks>
    /// Calls from services
    /// </remarks>
    /// <param name="userService"></param>
    /// <returns></returns>
    public static async Task<GetActiveUsersResponse> GetActiveUsersAsync(
        [FromServices] IUserService userService)
    {
        var userEntities = await userService.GetActiveUsersAsync();
        var userDtos = userEntities.Select(UserDtoMapper.FromEntityToDto);
        
        return new GetActiveUsersResponse(userDtos);
    }
    /*
     *  Other way to write the method signature, to return a Result type
    public static async Task<OK<GetActiveUsersRespons>, NotFound> GetActiveUsersAsync(
    [FromServices] IUserService userService)
    */
    public static IEndpointRouteBuilder RegisterUserEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        // GetActiveUsersAsync endpoint
        routeBuilder
            .MapGet("/active-users", GetActiveUsersAsync)
            .WithName("GetActiveUsers")
            .WithOpenApi();

        return routeBuilder;
    }
}
