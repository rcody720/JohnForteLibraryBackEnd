using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JohnForteLibrary.Domain.Specifications
{
    public class BooksByAvailabilitySpecification : ISpecification<Book>
    {
        public Expression<Func<Book, bool>> ToExpression()
        {
            return x => x.IsCheckedOut == false;
        }
    }
}
