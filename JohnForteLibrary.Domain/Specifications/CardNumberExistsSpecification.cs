using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JohnForteLibrary.Domain.Specifications
{
    public class CardNumberExistsSpecification : ISpecification<Patron>
    {
        public string CardNumber { get; set; }

        public CardNumberExistsSpecification(string cardNumber)
        {
            CardNumber = cardNumber;
        }

        public Expression<Func<Patron, bool>> ToExpression()
        {
            if(CardNumber != "")
            {
                return x => x.Card.Value == CardNumber;
            }

            return x => true;
        }
    }
}
