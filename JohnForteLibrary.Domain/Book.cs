using JohnForteLibrary.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JohnForteLibrary.Domain
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();       
        public ISBN ISBN { get; private set; }
        public int PublishedYear { get; private set; }
        public bool IsCheckedOut { get; private set; } = false;
        public Patron Patron { get; private set; }
        public DateTime? CheckedOutDate { get; private set; }
        public DateTime? DueDate { get; private set; }

        protected Book()
        {

        }

        public Book(string title, List<Author> authors, ISBN isbn, int publishedYear)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title cannot be null or empty.");
            }
            Title = title;
            if (authors != null)
            {
                Authors = authors;
            }
            if (publishedYear < 0 || publishedYear > DateTime.Now.Year)
            {
                throw new ArgumentException("Published year must be positive and not greater than the current year");
            }
            PublishedYear = publishedYear;
            ISBN = isbn;

        }

        public void CheckoutBook(Patron patron)
        {
            IsCheckedOut = true;
            Patron = patron;
            CheckedOutDate = DateTime.Now;
            DueDate = DateTime.Now.AddDays(21);
        }

        public void CheckinBook()
        {
            IsCheckedOut = false;
            Patron = null;
        }


    }
}
