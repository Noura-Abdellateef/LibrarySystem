using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks(CancellationToken cancellationToken = default);
        Task<IEnumerable<Book>> GetAllByAuhorIdAsync(long bookId, CancellationToken cancellationToken = default);

        Task<Book> GetByIdAsync(long bookId, CancellationToken cancellationToken = default);
        void Insert(Book book);
        void Remove(Book book);

    }
}
