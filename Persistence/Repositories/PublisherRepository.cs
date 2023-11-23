using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Repositories
{
    internal class PublisherRepository : IPublisherRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PublisherRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;
        public async Task<IEnumerable<Publisher>> GetAllPublisherAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.Publishers.ToListAsync(cancellationToken);

        public async Task<Publisher> GetByIdAsync(long publisherId, CancellationToken cancellationToken = default) =>

        await _dbContext.Publishers.FirstOrDefaultAsync(x => x.Id == publisherId, cancellationToken);

        public void Insert(Publisher publisher) =>
            _dbContext.Publishers.Add(publisher);
        

        public void Remove(Publisher publisher) =>
        _dbContext.Publishers.Remove(publisher);
    }
}
