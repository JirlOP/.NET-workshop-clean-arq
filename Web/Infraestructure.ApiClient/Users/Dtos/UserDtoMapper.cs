using Riok.Mapperly.Abstractions;
using UCR.ECCI.IS.ExampleProject.Domain.Users.Entities;
using UCR.ECCI.IS.ExampleProject.Domain.Users.ValueObjects;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Models;

namespace UCR.ECCI.IS.ExampleProject.Infraestructure.ApiClient.Users.Dtos;


// Mapper: a class that contains the mapping logic between two objects
[Mapper]
internal static partial class UserDtoMapper // partial: allows to split the definition of a class, a struct, an interface or a method over two or more source files
{
    // possible error: The value objects are not mapped
    /// <summary>
    /// Maps a User entity to a User DTO.
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns></returns>
    // internal static partial Domain.Users.Entities.User ToEntity(Client.Models.User userDto);
    internal static partial User ToEntity(UserDto userDto);

    /// <summary>
    /// Maps a User entity Email Value Object to a Email DTO
    /// </summary>
    /// <param name="emailDto"></param>
    /// <returns></returns>
    // internal static Domain.Users.ValueObjects.Email ToValueObject(Client.Models.Email emailDto)
    internal static Email ToEmailDto(string email)
    {
        return Email.Create(email);
    }

    /// <summary>
    /// Maps a User entity Name Value Object to a Name DTO
    /// </summary>
    /// <param name="nameDto"></param>
    /// <returns></returns>
    // internal static Domain.Users.ValueObjects.Name ToValueObject(Client.Models.Name nameDto)
    internal static Name ToNameDto(string name)
    {
        return Name.Create(name);
    }
}
