using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FakeItEasy;
using JohnForteLibrary.Domain;
using JohnForteLibrary.Domain.ValueObjects;
using System.Threading.Tasks;
using JohnForteLibrary.Domain.Repositories;
using JohnForteLibrary.Domain.Enums;

namespace JohnForteLibrary.UnitTests.Domain
{
    public class When_returning_a_book
    {
        [Fact]
        public void With_valid_cardNumber()
        {
            var bookRepo = A.Fake<IWritableRepo<Book>>();
            var book = new Book("TestBook", new List<Author> { new Author("William"), new Author("Martin") }, ISBN.Create("1234567891234").Value, 1950);
            var patron = A.Fake<Patron>();
            book.CheckoutBook(patron);
            book.CheckinBook();

            A.CallTo(() => bookRepo.Update(A<Book>.Ignored)).Returns(Task.FromResult(true));

            var bookToCheck = bookRepo.Update(book);

            Assert.True(bookToCheck.Result);
            Assert.False(book.IsCheckedOut);
            A.CallTo(() => bookRepo.Update(A<Book>.Ignored)).MustHaveHappened();
        }
    }
}
