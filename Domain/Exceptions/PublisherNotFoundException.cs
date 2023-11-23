using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class PublisherNotFoundException : NotFoundException
    {
        public PublisherNotFoundException(long publisherId)
            : base($"The publisher with the identifier {publisherId} was not found.")
        {
        }
    }
}
