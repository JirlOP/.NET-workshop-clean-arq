using UCR.ECCI.IS.ExampleProject.Domain.Users.Entities;
using UCR.ECCI.IS.ExampleProject.Domain.Users.Repositories;

namespace UCR.ECCI.IS.ExampleProject.Application.Users.Services;

// internal: access is limited to the current project
/// <summary>
/// Provide the communication between the application layer and the domain layer to manage the user entity services.
/// </summary>
/// <remarks>
/// This class implements the IUserService interface and have dependency injection of IUserRepository.
/// </remarks>
internal class UserService : IUserService
{
    // Pattern of Dependency Injection, constructor injection, readonly field and interface inheritance
    private readonly IUserRepository _userRepository;

    // we obtain the x implementation of IUserRepository through dependency injection by the constructor argument
    // I need someone that implements IUserRepository
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<IEnumerable<User>> GetActiveUsersAsync()
    {
        return _userRepository.GetActiveUsersAsync();
    }

}
