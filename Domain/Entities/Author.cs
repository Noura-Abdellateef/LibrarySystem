using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Author : BaseEntity<long>, IEntity
    {
        
        public required string Name { get; set; }
        public List<Book>? Books { get; set; }

    }
}
