using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnForteLibrary.Domain.ValueObjects
{
    public class PhoneNumber : SimpleValueObject<string>
    {
        private PhoneNumber(string value) : base(value) { }

        public static Result<PhoneNumber> Create(string number)
        {

            if (string.IsNullOrEmpty(number))
            {
                return Result.Success(new PhoneNumber(number));
            }

            var numberOfDashesAndParenthesese = 0;

            foreach (char c in number)
                if (c == '-' || c == '(' || c == ')') numberOfDashesAndParenthesese++;

            var numberOfDigits = number.Length - numberOfDashesAndParenthesese;

            if (numberOfDigits != 10)
                return Result.Failure<PhoneNumber>("Phone number should be 10 digits in length.");

            string newNumber = number.Replace("-", "").Replace("(", "").Replace(")", "");
            long longNumber = 0;
            bool result = long.TryParse(newNumber, out longNumber);

            if (!result)
                return Result.Failure<PhoneNumber>("Phone Number must be in a valid format: only use numbers with dashes and parenthesese");

            return Result.Success(new PhoneNumber(number));
        }

    }
}
