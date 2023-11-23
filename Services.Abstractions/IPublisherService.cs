using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IPublisherService
    {
        Task<IEnumerable<PublisherDto>> GetAllPublisherAsync(CancellationToken cancellationToken = default);
        Task<PublisherDto> GetByIdAsync(long publisherId, CancellationToken cancellationToken);

        Task<PublisherDto> CreateAsync( PublisherForCreationDto publisherForCreationDto, CancellationToken cancellationToken = default);
        Task UpdateAsync(long publisherId, PublisherForUpdateDto publisherForUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(long publisherId, CancellationToken cancellationToken = default);
    }

}
