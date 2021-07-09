using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnForteLibrary.Domain.ValueObjects
{
    public class ISBN : SimpleValueObject<string>
    {
        private ISBN(string value) : base(value) {}

        public static Result<ISBN> Create(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return Result.Failure<ISBN>("ISBN should not be empty");

            var numberOfDashes = 0;

            foreach (char c in isbn)
                if (c == '-') numberOfDashes++;

            var numberOfDigits = isbn.Length - numberOfDashes;

            if (numberOfDigits != 10 && numberOfDigits != 13)
                return Result.Failure<ISBN>("ISBN must be in a valid format: ten or thirteen digits.");

            string newIsbn = isbn.Replace("-", "");
            string newestIsbn = newIsbn.ToUpper().Replace("X", "0");
            long longIsbn = 0;
            bool result = long.TryParse(newestIsbn, out longIsbn);

            if (isbn.ToUpper().IndexOf('X') != isbn.Length - 1 && isbn.ToUpper().IndexOf('X') != -1) { result = false; }

            if (!result)
                return Result.Failure<ISBN>("ISBN must be in a valid format: only use numbers and dashes");

            return Result.Success(new ISBN(isbn));
        }
    }
}
