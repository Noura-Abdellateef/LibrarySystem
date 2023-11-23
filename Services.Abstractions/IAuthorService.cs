using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
   public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthorAsync(CancellationToken cancellationToken = default);
        Task<AuthorDto> GetByIdAsync(long authorId, CancellationToken cancellationToken);
         Task<AuthorDto> CreateAsync(AuthorForCreationDto authorForCreationDto, CancellationToken cancellationToken = default);
        Task UpdateAsync(long authorId, AuthorForUpdateDto authorForUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(long authorId, CancellationToken cancellationToken = default);
    }
}
