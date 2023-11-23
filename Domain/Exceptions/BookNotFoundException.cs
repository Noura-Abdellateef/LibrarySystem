using System;

namespace Domain.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(long bookId)
            : base($"The book with the identifier {bookId} was not found.")    
        {
        }
    }
}
