using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JohnForteLibrary.Domain.Specifications
{
    class BookByIsbnSpecification : ISpecification<Book>
    {
        public string Isbn { get; private set; }

        public BookByIsbnSpecification(string isbn)
        {
            Isbn = isbn;
        }

        public Expression<Func<Book, bool>> ToExpression()
        {
            if (!string.IsNullOrEmpty(Isbn))
            {
                return x => x.ISBN == Isbn;
            }

            return x => true;
        }
    }
}
