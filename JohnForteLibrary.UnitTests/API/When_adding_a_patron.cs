using System;
using System.Collections.Generic;
using System.Text;
using FakeItEasy;
using Xunit;
using System.Threading.Tasks;
using JohnForteLibrary.Domain;
using JohnForteLibrary.Domain.Repositories;
using JohnForteLibrary.Domain.ValueObjects;
using JohnForteLibrary.Domain.Enums;

namespace JohnForteLibrary.UnitTests.API
{
    public class When_adding_a_patron
    {
        [Fact]
        public void With_valid_card_data()
        {
            var libraryCardRepo = A.Fake<IWritableRepo<Patron>>();

            var cardToAdd = new Patron(PersonName.Create("Bob", "Smith").Value, Address.Create("29345 135th St.", "Olathe", State.KS, "66062").Value,
                            PhoneNumber.Create("183-349-2483").Value, EmailAddress.Create("bsmith@gmail.com").Value, new CardNumber("19385948394839"));

            A.CallTo(() => libraryCardRepo.Add(A<Patron>.Ignored)).Returns(Task.FromResult(cardToAdd));

            var cardToCheck = libraryCardRepo.Add(cardToAdd);

            Assert.Equal(cardToAdd.Card.CardNumber, cardToCheck.Result.Card.CardNumber);
            A.CallTo(() => libraryCardRepo.Add(A<Patron>.Ignored)).MustHaveHappened();
        }
    }
}
