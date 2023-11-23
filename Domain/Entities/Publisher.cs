using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Publisher : BaseEntity<int>, IEntity
    {
        public required string Name { get; set; }
        public List<Book> Books { get; } = new();

    }
}
