using UCR.ECCI.IS.ExampleProject.Presentation.Api.Users.Dtos;

namespace UCR.ECCI.IS.ExampleProject.Presentation.Api.Users.Responses;

/// <summary>
/// Class that represents the response of the GetActiveUsers method
/// </summary>
/// <param name="ActiveUsers"></param>
public record GetActiveUsersResponse(IEnumerable<UserDto> ActiveUsers);