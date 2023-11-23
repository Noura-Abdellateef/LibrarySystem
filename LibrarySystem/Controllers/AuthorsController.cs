using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthorsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetAuthors(CancellationToken cancellationToken)
        {
            var authorsDto = await _serviceManager.AuthorService.GetAllAuthorAsync(cancellationToken);

            return Ok(authorsDto);
        }
        [HttpGet("{Id:long}")]
        public async Task<IActionResult> GetAuthorById(long Id, CancellationToken cancellationToken)
        {
            var authorDto = await _serviceManager.AuthorService.GetByIdAsync(Id, cancellationToken);

            return Ok(authorDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor( [FromBody] AuthorForCreationDto authorForCreationDto, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.AuthorService.CreateAsync(authorForCreationDto, cancellationToken);

            return CreatedAtAction(nameof(GetAuthorById), new { Id = response.Id }, response);
        }
        
        [HttpPut("{Id:long}")]
        public async Task<IActionResult> UpdateAuthor(long Id, [FromBody] AuthorForUpdateDto authorForUpdateDto, CancellationToken cancellationToken)
        {
            await _serviceManager.AuthorService.UpdateAsync(Id, authorForUpdateDto, cancellationToken);
            return Ok("Author updateded successfully");
           
        }

        [HttpDelete("{Id:long}")]
        public async Task<IActionResult> DeleteAuthor(long Id, CancellationToken cancellationToken)
        {
            await _serviceManager.AuthorService.DeleteAsync(Id, cancellationToken);
            return Ok("Author deleted successfully");
            
        }
    }
}
