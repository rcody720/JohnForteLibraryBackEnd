using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JohnForteLibrary.Domain.Specifications
{
    public interface ISpecification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();
    }
}
