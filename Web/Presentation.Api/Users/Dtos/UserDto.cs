namespace UCR.ECCI.IS.ExampleProject.Presentation.Api.Users.Dtos;

/// <summary>
/// Data Transfer Object (DTO) for the User entity with shortened properties
/// </summary>
/// <param name="UserId"></param>
/// <param name="Name"></param>
/// <param name="LastName"></param>
/// <param name="Email"></param>
/// <param name="isActive"></param>
public record UserDto(Guid UserId, string Name, string LastName, string Email, bool isActive);
// record: a reference type that provides built-in functionality for encapsulating data
