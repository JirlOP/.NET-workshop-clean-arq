using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.IS.ExampleProject.Domain.Users.Entities;
using UCR.ECCI.IS.ExampleProject.Domain.Users.ValueObjects;

namespace UCR.ECCI.IS.ExampleProject.Infraestructure.Users.EntityConfigurations;

internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    /// <summary>
    /// Use this method to configure the entity of the User class.
    /// </summary>
    /// <remarks>
    /// Use the builder pattern to configure the entity of the User class.
    /// To establish the configuration we need to do it in DbContext class.
    /// </remarks>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.Property(u => u.IsActive)
            .IsRequired(); // Not Null

        builder.HasKey(u => u.UserId);

        // explicit configuration of the properties in the case of complex Data Types
        builder.Property(u => u.Name)
            .IsRequired() // Not Null
            .HasMaxLength(Name.MAXLENGTH)
            .HasConversion(
                // C# -> SQL conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: nameString => Name.Create(nameString)
            );

        builder.Property(u => u.LastName)
             .IsRequired() // Not Null
             .HasMaxLength(Name.MAXLENGTH)
             .HasConversion(
                 // C# -> SQL conversion
                 convertToProviderExpression: valueObject => valueObject.Value,
                 // SQL -> C# conversion
                 convertFromProviderExpression: lastNameString => Name.Create(lastNameString)
             );

        builder.Property(u => u.Email)
            .IsRequired() // Not Null
            .HasMaxLength(Email.MAXLENGTH)
            .HasConversion(
                // C# -> SQL conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: emailString => Email.Create(emailString)
            );

        builder.Property(u => u.UserId)
            .HasConversion(
                // C# -> SQL conversion
                convertToProviderExpression: guid => guid.ToString(),
                // SQL -> C# conversion
                convertFromProviderExpression: idString => Guid.Parse(idString)
            );
    }
}
