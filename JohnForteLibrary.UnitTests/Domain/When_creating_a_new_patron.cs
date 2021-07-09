using System;
using System.Collections.Generic;
using System.Text;
using CSharpFunctionalExtensions;
using FakeItEasy;
using JohnForteLibrary.Domain;
using JohnForteLibrary.Domain.Enums;
using JohnForteLibrary.Domain.ValueObjects;
using Xunit;

namespace JohnForteLibrary.UnitTests.Domain
{
    public class When_creating_a_new_patron
    {
        [Fact]
        public void With_good_data()
        {
            var name = PersonName.Create("Bob", "Smith").Value;
            var address = Address.Create("29345 135th St.", "Olathe", State.KS, "66062").Value;
            var phoneNum = PhoneNumber.Create("183-349-2483").Value;
            var email = EmailAddress.Create("bsmith@gmail.com").Value;
            var card = CardNumber.Create().Value;
            var patron = new Patron(name, address, phoneNum, email, card);
            Assert.Equal(name, patron.Name);
            Assert.Equal(address, patron.Address);
            Assert.Equal(phoneNum, patron.PhoneNumber);
            Assert.Equal(email, patron.Email);
            Assert.Equal(card, patron.Card);
        }

        [Fact]
        public void With_null_name()
        {
            var address = Address.Create("29345 135th St.", "Olathe", State.KS, "66062").Value;
            var phoneNum = PhoneNumber.Create("183-349-2483").Value;
            var email = EmailAddress.Create("bsmith@gmail.com").Value;
            var card = CardNumber.Create().Value;
            Assert.Throws<ResultFailureException>(() => new Patron(PersonName.Create(null, null).Value, address, phoneNum, email, card));
        }

        [Fact]
        public void With_null_last_name()
        {
            var address = Address.Create("29345 135th St.", "Olathe", State.KS, "66062").Value;
            var phoneNum = PhoneNumber.Create("183-349-2483").Value;
            var email = EmailAddress.Create("bsmith@gmail.com").Value;
            var card = CardNumber.Create().Value;
            Assert.Equal("Braden", new Patron(PersonName.Create("Braden", null).Value, address, phoneNum, email, card).Name.FirstName);
        }

        [Fact]
        public void With_null_first_name()
        {
            var address = Address.Create("29345 135th St.", "Olathe", State.KS, "66062").Value;
            var phoneNum = PhoneNumber.Create("183-349-2483").Value;
            var email = EmailAddress.Create("bsmith@gmail.com").Value;
            var card = CardNumber.Create().Value;
            Assert.Equal("Braden", new Patron(PersonName.Create(null, "Braden").Value, address, phoneNum, email, card).Name.LastName);
        }

        [Fact]
        public void With_null_Address()
        {
            var name = PersonName.Create("Braden", null).Value;
            var phoneNum = PhoneNumber.Create("183-349-2483").Value;
            var email = EmailAddress.Create("bsmith@gmail.com").Value;
            var card = CardNumber.Create().Value;
            Assert.Throws<ResultFailureException>(() => new Patron(name, Address.Create(null,null, State.None, null).Value, phoneNum, email, card));
        }

        [Fact]
        public void With_one_null_Address_property()
        {
            var name = PersonName.Create("Braden", null).Value;
            var phoneNum = PhoneNumber.Create("183-349-2483").Value;
            var email = EmailAddress.Create("bsmith@gmail.com").Value;
            var card = CardNumber.Create().Value;
            Assert.Throws<NullReferenceException>(() => new Patron(name, Address.Create("19384 135th St.", "Olathe", State.KS, null).Value, phoneNum, email, card));
        }
    }
}
