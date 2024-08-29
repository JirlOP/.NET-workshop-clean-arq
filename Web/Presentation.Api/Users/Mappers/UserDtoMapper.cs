using Riok.Mapperly.Abstractions;
using UCR.ECCI.IS.ExampleProject.Domain.Users.Entities;
using UCR.ECCI.IS.ExampleProject.Domain.Users.ValueObjects;
using UCR.ECCI.IS.ExampleProject.Presentation.Api.Users.Dtos;

namespace UCR.ECCI.IS.ExampleProject.Presentation.Api.Users.Mappers;

[Mapper]
public partial class UserDtoMapper
{
    public static partial UserDto FromEntityToDto(User user);

    public static string NameToString(Name name) => name.Value;
    public static string EmailToString(Email email) => email.Value;
}