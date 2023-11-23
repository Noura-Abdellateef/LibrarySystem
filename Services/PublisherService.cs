using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;


namespace Services
{
    internal sealed class PublisherService : IPublisherService
    {

        private readonly IUnitOfWork _unitOfWork;
        public PublisherService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<PublisherDto> CreateAsync( PublisherForCreationDto publisherForCreationDto, CancellationToken cancellationToken = default)
        {
            var publisher = publisherForCreationDto.Adapt<Publisher>();

            _unitOfWork.publisherRepository.Insert(publisher);

            await _unitOfWork.repositoryManager.SaveChangesAsync(cancellationToken);

            return publisher.Adapt<PublisherDto>();
        }

        public async Task DeleteAsync(long publisherId, CancellationToken cancellationToken = default)
        {
            var publisher = await _unitOfWork.publisherRepository.GetByIdAsync(publisherId, cancellationToken);

            if (publisher is null)
            {
                throw new PublisherNotFoundException(publisherId);
            }

            _unitOfWork.publisherRepository.Remove(publisher);

            await _unitOfWork.repositoryManager.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<PublisherDto>> GetAllPublisherAsync(CancellationToken cancellationToken = default)
        {
            var publishers = await _unitOfWork.publisherRepository.GetAllPublisherAsync(cancellationToken);

            if (publishers is null)
            {

            }
            var publisherDto = publishers.Adapt<IEnumerable<PublisherDto>>();

            return publisherDto;
        }

        public async  Task<PublisherDto> GetByIdAsync(long publisherId, CancellationToken cancellationToken)
        {
            var publisher = await _unitOfWork.publisherRepository.GetByIdAsync(publisherId, cancellationToken);

            if (publisher is null)
            {
                throw new PublisherNotFoundException(publisherId);
            }

            var publisherDto = publisher.Adapt<PublisherDto>();

            return publisherDto;
        }

        public async Task UpdateAsync(long publisherId, PublisherForUpdateDto publisherForUpdateDto, CancellationToken cancellationToken = default)
        {

            var publisher = await _unitOfWork.publisherRepository.GetByIdAsync(publisherId, cancellationToken);

            if (publisher is null)
            {
                throw new PublisherNotFoundException(publisherId);
            }

            publisher.Name = publisherForUpdateDto.Name;
            publisher.CreatedBy = publisherForUpdateDto.CreatedBy;
            publisher.IsDeleted = publisherForUpdateDto.IsDeleted;
            publisher.LastModifiedBy = publisherForUpdateDto.LastModifiedBy;
            publisher.LastModifiedOnUtc = publisherForUpdateDto.LastModifiedOnUtc;
            await _unitOfWork.repositoryManager.SaveChangesAsync(cancellationToken);
        }
    }
}
