using JohnForteLibrary.API.Dtos;
using JohnForteLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohnForteLibrary.API.Responses
{
    public class GetBookByIdResponse
    {
        public BookDto Book { get; set; }
    }
}
