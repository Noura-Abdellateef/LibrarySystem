using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
   public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> GetAllPublisherAsync( CancellationToken cancellationToken = default);

        Task<Publisher> GetByIdAsync(long publisherId, CancellationToken cancellationToken = default);
        void Insert(Publisher publisher);

        void Remove(Publisher publisher);
    }
}
