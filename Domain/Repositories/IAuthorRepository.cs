using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorAsync( CancellationToken cancellationToken = default);

        Task<Author> GetByIdAsync(long authorId, CancellationToken cancellationToken = default);
        void Insert(Author author);

        void Remove(Author author);
    }
}
