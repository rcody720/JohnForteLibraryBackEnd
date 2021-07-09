using JohnForteLibrary.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohnForteLibrary.API.Responses
{
    public class GetBooksByPatronIdResponse
    {
        public List<BookDto> Books { get; set; }
    }
}
