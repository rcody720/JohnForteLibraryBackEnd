
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FakeItEasy;
using JohnForteLibrary.Domain.Repositories;
using JohnForteLibrary.Domain;
using System.Threading.Tasks;

namespace JohnForteLibrary.UnitTests.API
{
    public class When_deleting_a_book
    {
        [Fact]
        public void With_valid_bookId()
        {
            var bookRepo = A.Fake<IWritableRepo<Book>>();

            var book = A.Fake<Book>();

            A.CallTo(() => bookRepo.Add(A<Book>.Ignored)).Returns(Task.FromResult(book));

            var bookFromAdd = bookRepo.Add(book).Result;

            A.CallTo(() => bookRepo.Delete(A<Book>.Ignored)).Returns(Task.FromResult(true));

            Assert.True(bookRepo.Delete(bookFromAdd).Result);
            A.CallTo(() => bookRepo.Delete(A<Book>.Ignored)).MustHaveHappened();
        }
    }
}