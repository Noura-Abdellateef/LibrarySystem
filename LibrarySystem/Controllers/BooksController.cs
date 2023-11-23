using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public BooksController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetBooks(CancellationToken cancellationToken)
        {
            var booksDto = await _serviceManager.BookService.GetAllBookAsync (cancellationToken);

            return Ok(booksDto);
        }
        [HttpGet("{Id:long}")]
        public async Task<IActionResult> GetBookById(long Id, CancellationToken cancellationToken)
        {
            var booktDto = await _serviceManager.BookService.GetByIdAsync(Id, cancellationToken);

            return Ok(booktDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(long authorId, [FromBody] BookForCreationDto bookForCreationDto, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.BookService.CreateAsync(authorId, bookForCreationDto, cancellationToken);

            return CreatedAtAction(nameof(GetBookById), new {Id = response.Id }, response);
        }

        [HttpGet("{authorId:long}/ByAuthor")]
        public async Task<IActionResult> GetBookByAuthorId(long authorId, CancellationToken cancellationToken)
        {
            var booktDto = await _serviceManager.BookService.GetAllByAuthorIdAsync(authorId, cancellationToken);

            return Ok(booktDto);
        }

        [HttpPut("{Id:long}")]
        public async Task<IActionResult> UpdateBook(long Id, [FromBody] BookForUpdateDto bookForUpdateDto, CancellationToken cancellationToken)
        {
            await _serviceManager.BookService.UpdateAsync(Id, bookForUpdateDto, cancellationToken);
            return Ok("Book updateded successfully");
           
        }

        [HttpDelete("{Id:long}")]
        public async Task<IActionResult> DeleteBook(long Id, CancellationToken cancellationToken)
        {
            await _serviceManager.BookService.DeleteAsync(Id, cancellationToken);
            return Ok("Book deleted successfully");
           
        }

    }
}
