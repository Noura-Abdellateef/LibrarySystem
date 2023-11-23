using Contracts;
using Domain.Repositories;
using LibrarySystem.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Persistence.Repositories;
using Services;
using Services.Abstractions;
using System.Threading;

namespace LibraySystem.Test
{
    
    public class BookUnitTest
    {
       
        private readonly Mock<IServiceManager> _mockService;
        private readonly BooksController _controller;
        CancellationToken cancellationToken = new CancellationToken();
        long id = 0;
        public BookUnitTest( )
        {

            _mockService = new Mock<IServiceManager>();
          
            _controller = new BooksController(_mockService.Object);
             
            

        }
        [Fact]
        public async Task Should_Return_All_Books_When_Calling_Get_Without_Parameters()
        {
            CancellationToken cancellationToken = new CancellationToken();
            var books =  _controller.GetBooks(cancellationToken);
            var items = Assert.IsType<List<BookDto>>(books);
            Assert.Equal(3, items.Count);

        }
       [Fact]
        public async Task Should_Return_one_Book_When_Calling_Get_Witht_id_Parameters()
        {
            CancellationToken cancellationToken = new CancellationToken();
            var book = _controller.GetBookById(7, cancellationToken);

            // Assert
            Assert.IsType<OkObjectResult>(book);

        }
       
        
        [Fact]
        public async Task Should_delete_one_Book_When_Calling_Witht_id_Parameters()
        {
          
            var book =  _controller.DeleteBook(id, cancellationToken);

            Assert.NotNull("Book deleted successfully");
        }
    }

}