using FakeItEasy;
using JohnForteLibrary.Domain;
using JohnForteLibrary.Domain.Enums;
using JohnForteLibrary.Domain.Repositories;
using JohnForteLibrary.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JohnForteLibrary.UnitTests.Domain
{
    public class When_checking_out_a_book
    {
        [Fact]
        public void With_valid_cardNumber()
        {
            var bookRepo = A.Fake<IWritableRepo<Book>>();
            var book = new Book("TestBook", new List<Author> { new Author("William"), new Author("Martin") }, ISBN.Create("1234567891234").Value, 1950);

            var patron = new Patron(PersonName.Create("Bob", "Smith").Value, Address.Create("29345 135th St.", "Olathe", State.KS, "66062").Value,
                            PhoneNumber.Create("183-349-2483").Value, EmailAddress.Create("bsmith@gmail.com").Value, new CardNumber("19385948394839"));           

            book.CheckoutBook(patron);

            A.CallTo(() => bookRepo.Update(A<Book>.Ignored)).Returns(Task.FromResult(true));

            var bookToCheck = bookRepo.Update(book);

            Assert.True(bookToCheck.Result);
            Assert.True(book.IsCheckedOut);
            A.CallTo(() => bookRepo.Update(A<Book>.Ignored)).MustHaveHappened();
        }
    }
}