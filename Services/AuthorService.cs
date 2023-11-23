using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public async Task<AuthorDto> CreateAsync(AuthorForCreationDto authorForCreationDto, CancellationToken cancellationToken)
        {
            var author = authorForCreationDto.Adapt<Author>();

            _unitOfWork.authorRepository.Insert(author);

            await _unitOfWork.repositoryManager.SaveChangesAsync(cancellationToken);

            return author.Adapt<AuthorDto>();
        }

        public async Task DeleteAsync(long authorId, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.authorRepository.GetByIdAsync(authorId, cancellationToken);

            if (author is null)
            {
                throw new AuthorNotFoundException(authorId);
            }

            _unitOfWork.authorRepository.Remove(author);

            await _unitOfWork.repositoryManager.SaveChangesAsync(cancellationToken);

        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorAsync(CancellationToken cancellationToken)
        {
            var authors = await _unitOfWork.authorRepository.GetAllAuthorAsync(cancellationToken);

            if (authors is null)
            {

            }
            var authorDto = authors.Adapt<IEnumerable<AuthorDto>>();

            return authorDto;
        }

        public async Task<AuthorDto> GetByIdAsync(long authorId, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.authorRepository.GetByIdAsync(authorId, cancellationToken);

            if (author is null)
            {
                throw new AuthorNotFoundException(authorId);
            }

            var authorsDto = author.Adapt<AuthorDto>();

            return authorsDto;
        }

        public async Task UpdateAsync(long authorId, AuthorForUpdateDto authorForUpdateDto, CancellationToken cancellationToken)
        {

            var author = await _unitOfWork.authorRepository.GetByIdAsync(authorId, cancellationToken);

            if (author is null)
            {
                throw new AuthorNotFoundException(authorId);
            }

            author.Name = authorForUpdateDto.Name;
            author.CreatedBy = authorForUpdateDto.CreatedBy;
            author.IsDeleted = authorForUpdateDto.IsDeleted;
            author.LastModifiedBy = authorForUpdateDto.LastModifiedBy;
            author.LastModifiedOnUtc = authorForUpdateDto.LastModifiedOnUtc;
            await _unitOfWork.repositoryManager.SaveChangesAsync(cancellationToken);

        }
    }
}
