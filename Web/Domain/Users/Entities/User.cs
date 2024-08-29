using UCR.ECCI.IS.ExampleProject.Domain.Users.ValueObjects;

namespace UCR.ECCI.IS.ExampleProject.Domain.Users.Entities; // recommendation: namespace for each file class

// recommendation: one class instance for each class file
// Visual Studio use XML comments to generate documentation
/// <summary>
/// This represente a User entity of Users Table
/// It contains the user personal data
/// </summary>
/// <remarks>
/// All Users should inheredit from this class
/// </remarks>
public class User
{
    // The constructor obligate to pass complete user data
    /// <summary>
    /// Constructor of User entity
    /// </summary>
    /// <param name="userId"> The user identifier.s </param>
    /// <param name="name"> The user name. </param>
    /// <param name="lastName"> The user last name. </param>
    /// <param name="email"> The user email. </param>
    /// <param name="isActive"> The user status in the current state of the system. </param>
    public User(Guid userId, Name name, Name lastName, Email email, bool isActive)
    {
        UserId = userId;
        Name = name;
        LastName = lastName;
        Email = email;
        IsActive = isActive;
    }

    // Property definition(attribute, get and set abrev)
    // Guid: represents a globallly unique identifier 
    // Clean: the properties are read-only or inmutable when a new instance is created
    // Code vs Table: here we can define constraints that the table can't define
    // Value objects: The value object is a object to put instead of the primitive type, to do value comparison

    /// <summary>
    /// The user identifier.
    /// </summary>
    public Guid UserId { get; }

    /// <summary>
    /// The user name.
    /// </summary>
    public Name Name { get; }

    /// <summary>
    /// The user last name.
    /// </summary>
    public Name LastName {  get; } 

    /// <summary>
    /// The user email.
    /// </summary>
    public Email Email { get; }

    /// <summary>
    /// The user status in the current state of the system.
    /// </summary>
    public bool IsActive { get; private set; }

    public void SetInactive()
    {
        IsActive = false;
    }
}
