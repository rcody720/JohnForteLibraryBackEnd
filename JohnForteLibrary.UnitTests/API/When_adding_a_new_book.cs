using FakeItEasy;
using JohnForteLibrary.API.Controllers;
using JohnForteLibrary.API.Dtos;
using JohnForteLibrary.Domain;
using JohnForteLibrary.Domain.Repositories;
using JohnForteLibrary.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JohnForteLibrary.UnitTests.API
{
    public class When_adding_a_new_book
    {
        [Fact]
        public void With_valid_book_data()
        {
            var bookRepo = A.Fake<IWritableRepo<Book>>();

            var bookFromRepo = new Book("TestBook", new List<Author> { new Author("William"), new Author("Martin") }, ISBN.Create("1234567891234").Value, 1950);

            A.CallTo(() => bookRepo.Add(A<Book>.Ignored)).Returns(Task.FromResult(bookFromRepo));

            var bookToCheck = bookRepo.Add(bookFromRepo);            

            Assert.Equal(1, bookToCheck.Id);
            A.CallTo(() => bookRepo.Add(A<Book>.Ignored)).MustHaveHappened();
        }       
    }
} 
