using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UCR.ECCI.IS.ExampleProject.Domain.Users.Entities;

namespace UCR.ECCI.IS.ExampleProject.Infraestructure;

// TODOinternal class ApplicationDBContext : DbContext
public class ApplicationDBContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }

    /// <summary>
    /// To receive the connection string from the Startup class
    /// </summary>
    /// <param name="modelBuilder"></param>
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
        : base(options)
    {
    }

    [Obsolete("Is only used to mocking/testing purposes. DO NOT use it in production code.")]
    internal ApplicationDBContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Call the base class method

        // Manual version to apply the configuration. One per entity
        // modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

        // Automatic version to apply the configuration. One line for all the project entities
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
