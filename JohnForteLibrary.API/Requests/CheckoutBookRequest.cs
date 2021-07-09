using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohnForteLibrary.API.Requests
{
    public class CheckoutBookRequest
    {
        public int BookId { get; set; }
        public string CardNumber { get; set; }
    }
}
