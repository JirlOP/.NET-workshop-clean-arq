using Microsoft.EntityFrameworkCore;
using UCR.ECCI.IS.ExampleProject.Domain.Users.Entities;
using UCR.ECCI.IS.ExampleProject.Domain.Users.ValueObjects;

namespace UCR.ECCI.IS.ExampleProject.Infraestructure.Tests.Integration;

public class TestDatabaseFixture
{
    public const string TestConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DatabaseWindowsTests;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public ApplicationDBContext ApplicationDBContext { get; }

    public static IEnumerable<User> SeedUsers()
    {
        yield return new User(
            userId: Guid.Parse("9d190ba3-1ec6-4091-9781-d7f71a15b76a"),
            name: Name.Create("First"),
            lastName: Name.Create("Last"),
            email: Email.Create("first.last@email.com"),
            isActive: true);

        yield return new User(
            userId: Guid.Parse("e18cd860-e44e-461d-a0b4-127696944ade"),
            name: Name.Create("First2"),
            lastName: Name.Create("Last2"),
            email: Email.Create("first.last2@email.com"),
            isActive: false);

        yield return new User(
            userId: Guid.Parse("01093f29-8abf-4224-b84f-5d927e1baabd"),
            name: Name.Create("First3"),
            lastName: Name.Create("Last3"),
            email: Email.Create("first.last3@email.com"),
            isActive: true);
    }

    public TestDatabaseFixture()
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>()
            .UseSqlServer(TestConnectionString);
        ApplicationDBContext = new(dbContextOptionsBuilder.Options);
    }

    public async Task SeedDatabaseAsync()
    {
        // Delete all existing users
        await ApplicationDBContext
            .Users
            .ExecuteDeleteAsync();

        // Re-add the seed users
        await ApplicationDBContext
            .Users
            .AddRangeAsync(SeedUsers());

        await ApplicationDBContext
            .SaveChangesAsync();

        ApplicationDBContext
            .ChangeTracker
            .Clear();
    }

    public async Task SetAllUsersAsInactiveAsync()
    {
        var activeUsers = await ApplicationDBContext
            .Users
            .Where(u => u.IsActive)
            .ToListAsync();

        activeUsers.ForEach(u => u.SetInactive());

        await ApplicationDBContext
            .SaveChangesAsync();

        ApplicationDBContext
            .ChangeTracker
            .Clear();
    }
}
