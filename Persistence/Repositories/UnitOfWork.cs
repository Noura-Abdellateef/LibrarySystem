using System.Threading;
using System.Threading.Tasks;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {

        private readonly Lazy<IBookRepository> _lazyBookRepository;
        private readonly Lazy<IAuthorRepository> _lazyAuthorRepository;
        private readonly Lazy<IPublisherRepository> _lazyPublisherRepository;
        private readonly Lazy<IRepositoryManager> _lazyRepositoryManager;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _lazyBookRepository = new Lazy<IBookRepository>(() => new BookRepository(dbContext));
            _lazyAuthorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(dbContext));
            _lazyPublisherRepository = new Lazy<IPublisherRepository>(() => new PublisherRepository(dbContext));
           _lazyRepositoryManager = new Lazy<IRepositoryManager>(() => new RepositoryManager(dbContext));  
        }

        public IAuthorRepository authorRepository => _lazyAuthorRepository.Value;

        public IBookRepository bookRepository => _lazyBookRepository.Value;

        public IPublisherRepository publisherRepository => _lazyPublisherRepository.Value;
        public IRepositoryManager repositoryManager => _lazyRepositoryManager.Value;

      
    }
}