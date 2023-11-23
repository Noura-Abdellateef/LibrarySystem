using Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PublishersController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> Getublishers(CancellationToken cancellationToken)
        {
            var publishersDto = await _serviceManager.PublisherService.GetAllPublisherAsync(cancellationToken);

            return Ok(publishersDto);
        }


        [HttpGet("{Id:long}")]
        public async Task<IActionResult> GetPublisherById(long Id, CancellationToken cancellationToken)
        {
            var publisherDto = await _serviceManager.PublisherService.GetByIdAsync(Id, cancellationToken);

            return Ok(publisherDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublisher([FromBody] PublisherForCreationDto publisherForCreationDto, CancellationToken cancellationToken)
        {
            
            var response = await _serviceManager.PublisherService.CreateAsync(publisherForCreationDto, cancellationToken);

            return CreatedAtAction(nameof(GetPublisherById), new { Id= response.Id }, response);
        }

        [HttpPut("{Id:long}")]
        public async Task<IActionResult> UpdatePublisher(long Id, [FromBody] PublisherForUpdateDto publisherForUpdateDto, CancellationToken cancellationToken)
        {
            await _serviceManager.PublisherService.UpdateAsync(Id, publisherForUpdateDto, cancellationToken);

            return Ok("Publisher updateded successfully");

        }

        [HttpDelete("{Id:long}")]
        public async Task<IActionResult> DeletePublisher(long Id, CancellationToken cancellationToken)
        {
            await _serviceManager.PublisherService.DeleteAsync(Id, cancellationToken);

            return Ok("Publisher deleted successfully");
        }

    }
}
