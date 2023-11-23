using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUnitOfWork
    {
       IAuthorRepository authorRepository { get; }
        IBookRepository bookRepository { get; }
        IPublisherRepository publisherRepository { get; }
        IRepositoryManager repositoryManager { get; }
       
    }
}
