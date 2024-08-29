using Microsoft.EntityFrameworkCore;
using UCR.ECCI.IS.ExampleProject.Domain.Users.Entities;
using UCR.ECCI.IS.ExampleProject.Domain.Users.Repositories;

namespace UCR.ECCI.IS.ExampleProject.Infraestructure.Users.Repositories;

// can be internal because dependency injection is used providing other external layers access to the repository
internal class SqlUserRepository : IUserRepository
{
    private readonly ApplicationDBContext _dbContext;

    public SqlUserRepository(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<User>> GetActiveUsersAsync()
    {
        // await: Espera a que la tarea se complete
        return await _dbContext
            .Users
            .Where(u => u.IsActive)
            .ToListAsync();
        // Same as:
        // SELECT * FROM Users WHERE IsActive = 1
    }
}
