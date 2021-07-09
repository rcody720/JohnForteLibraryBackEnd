using JohnForteLibrary.Domain;
using JohnForteLibrary.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohnForteLibrary.API.Dtos
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public List<string> Authors { get; set; }       
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public bool IsOverdue { get; set; }
    }
}
