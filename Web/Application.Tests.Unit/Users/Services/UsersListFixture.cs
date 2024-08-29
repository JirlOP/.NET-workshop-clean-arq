using UCR.ECCI.IS.ExampleProject.Domain.Users.Entities;
using UCR.ECCI.IS.ExampleProject.Domain.Users.ValueObjects;

namespace UCR.ECCI.IS.ExampleProject.Application.Tests.Unit.Users.Services;

public class UsersListFixture
{
    public IEnumerable<User> UsersList { get; }
    public IEnumerable<User> ActiveUsersList { get; } 
        
    public UsersListFixture()
    {
        UsersList =
        [
            new User(
                Guid.NewGuid(),
                Name.Create("Jorge"),
                Name.Create("Sagot"),
                Email.Create("test1@test.test"),
                isActive: false
            ),
            new User(
                Guid.NewGuid(),
                Name.Create("Sara"),
                Name.Create("Espinoza"),
                Email.Create("test2@test.test"),
                isActive: true
            ),
            new User(
                Guid.NewGuid(),
                Name.Create("Christopher"),
                Name.Create("Viquez"),
                Email.Create("test3 @test.test"),
                isActive: true
            ),
        ];

        ActiveUsersList = 
            UsersList
                .Where(user => user.IsActive).ToList();
    }
}
