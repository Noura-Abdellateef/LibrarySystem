using System;

namespace Domain.Exceptions
{
    public sealed class AuthorNotFoundException : NotFoundException
    {
        public AuthorNotFoundException(long autherId)
            : base($"The auther with the identifier {autherId} was not found.")
        {
        }
    }
}
