
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public  interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBookAsync( CancellationToken cancellationToken = default);
        Task<IEnumerable<BookDto>> GetAllByAuthorIdAsync(long authorId, CancellationToken cancellationToken = default);

        Task<BookDto> GetByIdAsync(long bookId,  CancellationToken cancellationToken);

      Task<BookDto> CreateAsync(long authorId, BookForCreationDto bookForCreationDto, CancellationToken cancellationToken = default);
        Task UpdateAsync(long bookId, BookForUpdateDto bookForUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(long bookId, CancellationToken cancellationToken = default);
    }
}
