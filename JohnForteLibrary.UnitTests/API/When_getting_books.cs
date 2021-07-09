using FakeItEasy;
using JohnForteLibrary.Domain;
using JohnForteLibrary.Domain.Repositories;
using JohnForteLibrary.Domain.Specifications;
using JohnForteLibrary.Domain.ValueObjects;
using JohnForteLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JohnForteLibrary.UnitTests.API
{
    public interface testInterface : IReadableRepo<Book>, IWritableRepo<Book> { }
    public class When_getting_books
    {
        [Fact]
        public void Getting_All_Books()
        {
            var bookRepo = A.Fake<IReadableRepo<Book>>();
            A.CallTo(() => bookRepo.FindAll()).Returns(Task.FromResult(new List<Book> { A.Fake<Book>(), A.Fake<Book>(), A.Fake<Book>() }));
            Assert.Equal(3, bookRepo.FindAll().Result.Count);
            A.CallTo(() => bookRepo.FindAll()).MustHaveHappened();
        }
    }
}