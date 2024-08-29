using ECCI.UCR.IS.ExampleProject.Unity.Domain.Core;
using System;
using System.Collections.Generic;


namespace ECCI.UCR.IS.ExampleProject.Unity.Domain.Users.ValueObjects
{
    public class Email : ValueObject
    {

        public string Value { get; }

        // readonly: the value can be assigned only in the constructor or at the time of declaration
        //private static readonly Email Invalid = new(string.Empty);
        // => : expression-bodied member: a concise way to implement a read-only property
        private static Email Invalid => new(string.Empty);

        public const int MAXLENGTH = 320;

        private Email(string value)
        {
            Value = value;
        }

        // out: return a value by reference
        public static bool TryCreate(string value, out Email email)
        {
            // TODO : Implement a more robust email validation
            // Validation

            email = Invalid;

            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            if (!value.Contains('@') || !value.Contains('.'))
            {
                return false;
            }

            if (value.Length > MAXLENGTH)
            {
                return false;
            }

            // If validation passed, return true and create the object with Name constructor
            email = new Email(value);
            return true;

        }

        public static Email Create(string emailString)
        {
            var validation = TryCreate(emailString, out var email);
            if (!validation)
            {
                throw new ArgumentException("Invalid email");
            }
            return email;
        }

        public override string ToString()
        {
            return Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
