using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JohnForteLibrary.Domain.Specifications
{
    public class BooksByPatronIdSpecification : ISpecification<Book>
    {
        public int PatronId { get; private set; }

        public BooksByPatronIdSpecification(int patronId)
        {
            PatronId = patronId;
        }

        public Expression<Func<Book, bool>> ToExpression()
        {
            if(PatronId != 0)
            {
                return x => x.Patron.Id == PatronId && x.IsCheckedOut;
            }

            return x => true;
        }
    }
}
