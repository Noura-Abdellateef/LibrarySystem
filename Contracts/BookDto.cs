using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class BookDto:BaseDto
    {
        public long Id { get; set; }
       public string? Title { get; set; }
        public IEnumerable<PublisherDto>? publishers { get; set; }
        public long AuthorId { get; set; }
    }
}
