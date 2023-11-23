using Domain.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _lazyBookService;
        private readonly Lazy<IAuthorService> _lazyAuthorService;
        private readonly Lazy<IPublisherService> _lazyPublisherService;

      

        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _lazyBookService = new Lazy<IBookService>(() => new BookService(unitOfWork));
            _lazyAuthorService = new Lazy<IAuthorService>(() => new AuthorService(unitOfWork));
            _lazyPublisherService = new Lazy<IPublisherService>(() => new PublisherService(unitOfWork));
        }



        public IBookService BookService => _lazyBookService.Value;

        public IAuthorService AuthorService => _lazyAuthorService.Value;

        public IPublisherService PublisherService => _lazyPublisherService.Value;
    }
}
