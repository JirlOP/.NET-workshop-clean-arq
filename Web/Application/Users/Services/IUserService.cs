using UCR.ECCI.IS.ExampleProject.Domain.Users.Entities;

namespace UCR.ECCI.IS.ExampleProject.Application.Users.Services;

// interface: a contract that defines the methods that a class must implement
public interface IUserService
{
    // Task: represents an asynchronous operation
    // sufix Async: indicates that the method is asynchronous
    // IEnumerable: represents a collection of objects that can be enumerated
    /// <summary>
    /// Get all active users from the database
    /// </summary>
    /// <returns> A list of User entity objects </returns>
    public Task<IEnumerable<User>> GetActiveUsersAsync();

}
