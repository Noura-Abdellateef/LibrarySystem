using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book : BaseEntity<long>, IEntity
    {
        
        public required string Title { get; set; }
        public List<Publisher> publishers { get; } = new();
       public long AuthorId { get; set; }
    }
}
