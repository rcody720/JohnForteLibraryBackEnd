using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JohnForteLibrary.Domain.Specifications
{
    public class AuthorByNameSpecification : ISpecification<Author>
    {
        public string Name { get; private set; }

        public AuthorByNameSpecification(string name)
        {
            Name = name;
        }

        public Expression<Func<Author, bool>> ToExpression()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                return x => x.Name == Name;
            }

            return x => true;
        }
    }
}
