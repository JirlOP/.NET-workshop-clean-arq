using UCR.ECCI.IS.ExampleProject.Domain.Users.Entities;

namespace UCR.ECCI.IS.ExampleProject.Domain.Users.Repositories;

public interface IUserRepository
{
    /// <summary>
    /// Communicate with Infrastructure layer to get all active users
    /// Implementation of IUserService .GetActiveUsersAsync contract
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<User>> GetActiveUsersAsync();
}
