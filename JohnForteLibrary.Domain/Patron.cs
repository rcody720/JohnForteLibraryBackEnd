using JohnForteLibrary.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnForteLibrary.Domain
{
    public class Patron : Entity
    {

        public PersonName Name { get; private set; }
        public Address Address { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public EmailAddress Email { get; private set; }
        public CardNumber Card { get; set; }
        public List<Book> CheckedOutBooks { get; private set; } = new List<Book>();

        protected Patron() {}

        public Patron(PersonName name, Address address, PhoneNumber number, EmailAddress email, CardNumber card)
        {
            Name = name;
            Address = address;
            PhoneNumber = number;
            Email = email;
            Card = card;
        }

        public void ChangeName(PersonName name)
        {
            Name = name;
        }

        public void ChangePhoneNumber(PhoneNumber number)
        {
            PhoneNumber = number;
        }

        public void ChangeEmail(EmailAddress email)
        {
            Email = email;
        }

        public void ChangeAddress(Address address)
        {
            Address = address;
        }

        public void AddBookToCheckedOut(Book book)
        {
            CheckedOutBooks.Add(book);
        }
    }
}
