using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnForteLibrary.Domain.ValueObjects
{
    public class PersonName : ValueObject
    {

        private PersonName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException("First or last name is required.");

            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public static Result<PersonName> Create(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
                return Result.Failure<PersonName>("First and Last name should not be empty.");

            if (firstName != null && firstName.Trim().Length > 20)
                return Result.Failure<PersonName>("First name should be twenty characters or less.");                       

            if (lastName != null && lastName.Trim().Length > 30)
                return Result.Failure<PersonName>("Last name should be thirty characters or less.");

            return Result.Success(new PersonName(firstName, lastName));
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                return LastName;
            }
            else if (string.IsNullOrEmpty(LastName))
            {
                return FirstName;
            }
            return FirstName + " " + LastName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
