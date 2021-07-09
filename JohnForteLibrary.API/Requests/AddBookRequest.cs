using JohnForteLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohnForteLibrary.API.Requests
{
    public class AddBookRequest
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }        
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
    }
}
