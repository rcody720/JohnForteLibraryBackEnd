using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JohnForteLibrary.Domain.Specifications
{
    public class BookByTitleSpecification : ISpecification<Book>
    {
        public string Title { get; private set; }

        public BookByTitleSpecification(string title)
        {
            Title = title;
        }

        public Expression<Func<Book, bool>> ToExpression()
        {
            if (!string.IsNullOrEmpty(Title))
            {
                return x => x.Title.Contains(Title);
            }

            return x => true;
        }
    }
}
