using JohnForteLibrary.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohnForteLibrary.API.Dtos
{
    public class CardDto
    {
        public PersonName Name { get; set; }
        public string cardNumber { get; set; }
    }
}
