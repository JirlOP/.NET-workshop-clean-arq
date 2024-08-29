
using UCR.ECCI.IS.ExampleProject.Domain.Core;

namespace UCR.ECCI.IS.ExampleProject.Domain.Users.ValueObjects;

// Value objects are immutable objects that represent a value, they are used to encapsulate the data and behavior of a value conceptually

public class Name : ValueObject
{

    public string Value { get; }

    private static readonly Name Invalid = new(string.Empty);

    public static readonly char[] IllegalCharacters = 
        ['/', '\\', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '+', '=', '{', '}',
        '[', ']', '|', ':', ';', '"', '\'', '<', '>', ',', '.', '?', '`', '~'];

    public const int MAXLENGTH = 50;

    private Name(string value)
    {
        Value = value;
    }

    // out: return a value by reference
    // all the names would be created through this method, so we always have a valid name
    // ? : nullable type
    public static bool TryCreate(string? value, out Name name)
    {
        // Validation
        
        name = Invalid; // begins with invalid value because of validation process

        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        //if (value.Contains('/') || value.Contains('\\') ...) Not mantainable code, broken Open/Closed principle
        if (value.IndexOfAny(IllegalCharacters) != -1)
        {
            return false;
        }

        if (value.Length > MAXLENGTH)
        {
            return false;
        }

        // If validation passed, return true and create the object with Name constructor
        name = new Name(value);
        return true;

    }

    public static Name Create(string? nameString)
    {
        var validation = TryCreate(nameString, out var name);
        if(!validation) 
        { 
            throw new ArgumentException("Invalid name");
        }
        return name;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value; // yield: returns each element of the collection one at a time
        // yield return new object[] { Value }; // if we want to return an array
    }

    // TODO: re-check list of illegal chars
    // TODO: Implement value comparison(recharge the operator "==" to not compare references, else if strings)
    // TODO: localization, maybe common location for all value objects
}
