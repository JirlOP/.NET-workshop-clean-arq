

using UCR.ECCI.IS.ExampleProject.Domain.Users.ValueObjects;

namespace UCR.ECCI.IS.ExampleProject.Domain.Tests.Unit.Users.Entities;

public class UserValueObjectsFixture
{
    // mock objects
    private const string kInputName = "Jorge";
    private const string kInputLastName = "Sagot";
    private const string kInputEmail = "jorge.diazsagot@ucr.ac.cr";

    // VO Fixtures
    public Name Name { get; }
    public Name LastName { get; }
    public Email Email { get; }


    public UserValueObjectsFixture()
    {
        Name = Name.Create(kInputName);
        LastName = Name.Create(kInputLastName);
        Email = Email.Create(kInputEmail);
    }

}
