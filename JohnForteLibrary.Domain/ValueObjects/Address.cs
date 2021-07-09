using CSharpFunctionalExtensions;
using JohnForteLibrary.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JohnForteLibrary.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string StreetName { get; private set; }
        //public string AdditionalStreet { get; private set; } // For additional address info - apartment number, etc.
        public string City { get; private set; }
        public State State { get; private set; }
        public string ZipCode { get; private set; } // String since some zip codes can start with 0.

        protected Address() {}

        private Address(string streetName, string city, State state, string zip)
        {
            StreetName = streetName;
            //AdditionalStreet = additionalStreet;
            City = city;
            State = state;
            ZipCode = zip;
        }

        public static Result<Address> Create(string streetName, string city, State state, string zip)
        {
            // Add Validation checks
            if (String.IsNullOrEmpty(streetName))
            {
                return Result.Failure<Address>("An address must include a street name.");
            }

            if (String.IsNullOrEmpty(city))
            {
                return Result.Failure<Address>("An address must include a city.");
            }

            var filteredZip = zip.Replace("-", "").Trim();
            long longZip;
            var result = long.TryParse(filteredZip, out longZip);

            if (String.IsNullOrEmpty(zip) || !result)
            {
                return Result.Failure<Address>("A valid zip code must be made of digits and dashes only");
            }

            if (filteredZip.Length != 5 && filteredZip.Length != 9)
            {
                return Result.Failure<Address>("A valid zip code must contain either 5 or 9 digits.");
            }


            return Result.Success(new Address(streetName, city, state, zip));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StreetName;
            //yield return AdditionalStreet;
            yield return City;
            yield return State;
            yield return ZipCode;
        }

        public override string ToString()
        {
            return StreetName + ", " + City + ", " + State + " " + ZipCode;
        }
    }
}
