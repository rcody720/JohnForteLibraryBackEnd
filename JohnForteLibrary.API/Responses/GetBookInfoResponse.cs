using JohnForteLibrary.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohnForteLibrary.API.Responses
{
    public class GetBookInfoResponse
    {
        public PatronDto CheckedOutInfo { get; set; }
        public string DueDate { get; set; }
        public string CheckedOutDate { get; set; }
    }
}
