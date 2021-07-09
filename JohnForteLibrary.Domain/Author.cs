using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JohnForteLibrary.Domain
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }

        protected Author()
        {

        }

        public Author(string name)
        {
            Name = name;
        }
    }
}
