using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Repositories
{
    internal class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Author>> GetAllAuthorAsync( CancellationToken cancellationToken = default) =>

        await _dbContext.Authors.Include(x => x.Books).ToListAsync(cancellationToken);

        public async Task<Author> GetByIdAsync(long authorId, CancellationToken cancellationToken = default)=>
         await _dbContext.Authors.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == authorId, cancellationToken);

        public void Insert(Author author) => _dbContext.Authors.Add(author);

        public void Remove(Author author) => _dbContext.Authors.Remove(author);

    }
}
