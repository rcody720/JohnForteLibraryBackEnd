using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JohnForteLibrary.Domain.ValueObjects
{
    public class CardNumber : SimpleValueObject<string>
    {

        private CardNumber(string value) : base(value) {}


        public static Result<CardNumber> Create()
        {
            string cardNumber = "";

            var random = new Random();

            for (int i = 0; i < 14; i++)
                cardNumber += random.Next(0, 9).ToString();

            return Result.Success(new CardNumber(cardNumber));
            
        }
        
    }
}
