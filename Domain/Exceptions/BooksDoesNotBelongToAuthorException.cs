using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class BooksDoesNotBelongToAuthorException : BadRequestException
    {
        public BooksDoesNotBelongToAuthorException(long authorId)
            : base($"The  author with the identifier {authorId} does not belong to the books ")
        {

        }
    }
   
}
