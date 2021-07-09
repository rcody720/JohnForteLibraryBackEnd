using CSharpFunctionalExtensions;
using FakeItEasy;
using JohnForteLibrary.Domain;
using JohnForteLibrary.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JohnForteLibrary.UnitTests.Domain
{
    public class When_creating_a_new_book
    {
        [Fact]
        public void With_good_data()
        {
            int id = 0;
            string title = "Harry Potter";
            int year = 2000;
            ISBN isbn = ISBN.Create("1234567898765").Value;
            var authors = A.Fake<List<Author>>();
            var result = new Book(title, authors, isbn, year);
            Assert.Equal(title, result.Title);
            Assert.Equal(authors, result.Authors);
            Assert.Equal(year, result.PublishedYear);
            Assert.Equal(isbn, result.ISBN);
        }
        [Fact]
        public void With_null_author_data()
        {
            string title = "Harry Potter";
            int year = 2000;
            ISBN isbn = ISBN.Create("1234567898765").Value;
            var authors = new List<Author>();
            var result = new Book(title, null, isbn, year);
            Assert.Equal(authors, result.Authors);
        }
        [Fact]
        public void With_null_title()
        {           
            var authors = A.Fake<List<Author>>();
            ISBN isbn = ISBN.Create("1234567898765").Value;
            Assert.Throws<ArgumentException>(() => new Book(null, authors, isbn, 2000));
        }
        [Fact]
        public void With_empty_title()
        {
            ISBN isbn = ISBN.Create("1234567898765").Value;
            var authors = A.Fake<List<Author>>();
            Assert.Throws<ArgumentException>(() => new Book("", authors, isbn, 2000));
        }
        [Fact]
        public void With_a_negative_year()
        {
            var authors = A.Fake<List<Author>>();
            ISBN isbn = ISBN.Create("1234567898765").Value;
            Assert.Throws<ArgumentException>(() => new Book("Harry Potter", authors, isbn, -2000));
        }
        [Fact]
        public void With_a_future_year()
        {
            var authors = A.Fake<List<Author>>();
            ISBN isbn = ISBN.Create("1234567898765").Value;
            int currentYear = DateTime.Now.Year;
            Assert.Throws<ArgumentException>(() => new Book("Harry Potter", authors, isbn, currentYear + 1));
        }        
        [Fact]
        public void With_a_short_isbn()
        {
            var authors = A.Fake<List<Author>>();
            Assert.Throws<ResultFailureException>(() => new Book("Harry Potter", authors, ISBN.Create("567898765").Value, 2000));
        }
        [Fact]
        public void With_a_long_isbn()
        {
            var authors = A.Fake<List<Author>>();
            Assert.Throws<ResultFailureException>(() => new Book("Harry Potter", authors, ISBN.Create("123456789876542").Value, 2000));
        }
        [Fact]
        public void With_a_non_numeric_isbn()
        {
            var authors = A.Fake<List<Author>>();
            Assert.Throws<ResultFailureException>(() => new Book("Harry Potter", authors, ISBN.Create("123a567898765").Value, 2000));
        }
        [Fact]
        public void With_a_null_isbn()
        {
            var authors = A.Fake<List<Author>>();
            var result = new Book("Harry Potter", authors, null, 2000);
            Assert.Null(result.ISBN);
        }
    }
}
