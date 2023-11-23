using System;
using Domain.Repositories;

namespace Persistence.Repositories
{
    internal sealed class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _dbContext;

        public RepositoryManager(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            _dbContext.SaveChangesAsync(cancellationToken);
      

    }
}
