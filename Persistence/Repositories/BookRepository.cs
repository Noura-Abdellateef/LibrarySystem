using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Repositories
{
    internal sealed class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public async Task<IEnumerable<Book>> GetAllBooks(CancellationToken cancellationToken) =>
          await _dbContext.Books.ToListAsync(cancellationToken);

        public BookRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Book>> GetAllByAuhorIdAsync(long auhorId, CancellationToken cancellationToken = default) =>
                   await _dbContext.Books.Where(x => x.AuthorId == auhorId).ToListAsync(cancellationToken);


        public async Task<Book> GetByIdAsync(long bookId, CancellationToken cancellationToken = default) =>
            await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == bookId, cancellationToken);


        public void Insert(Book book) =>
         _dbContext.Books.Add(book);

        public void Remove(Book book) =>
            _dbContext.Books.Remove(book);



    }
}
