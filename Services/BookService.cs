using Contracts;
using Domain.Repositories;
using Services.Abstractions;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using System.Security.Principal;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    internal sealed class BookService : IBookService
    {

        private readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;


        public async Task<IEnumerable<BookDto>> GetAllBookAsync(CancellationToken cancellationToken = default)
        {
            var books = await _unitOfWork.bookRepository.GetAllBooks(cancellationToken);

            if(books is null)
            {

            }
            var bookDto = books.Adapt<IEnumerable<BookDto>>();

            return bookDto;
        }
        public async Task<IEnumerable<BookDto>> GetAllByAuthorIdAsync(long authorId, CancellationToken cancellationToken = default)
        {
            var books = await _unitOfWork.bookRepository.GetAllByAuhorIdAsync(authorId, cancellationToken);

            if (books is null)
            {
                throw new BooksDoesNotBelongToAuthorException(authorId);
            }
            var booksDto = books.Adapt<IEnumerable<BookDto>>();
           
            return booksDto;
        }

        public async Task<BookDto> GetByIdAsync(long bookId, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.bookRepository.GetByIdAsync(bookId, cancellationToken);

            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }

            var booksDto = book.Adapt<BookDto>();

            return booksDto;
        }

        public async Task<BookDto> CreateAsync(long authorId, BookForCreationDto bookForCreationDto, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.authorRepository.GetByIdAsync(authorId, cancellationToken);

            if (author is null)
            {
                throw new AuthorNotFoundException(authorId);
            }

            var book = bookForCreationDto.Adapt<Book>();

            book.AuthorId =authorId;

            _unitOfWork.bookRepository.Insert(book);

            await _unitOfWork.repositoryManager.SaveChangesAsync(cancellationToken);

            return book.Adapt<BookDto>();
        }


        public async Task DeleteAsync(long bookId, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.bookRepository.GetByIdAsync(bookId, cancellationToken);

            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }

            _unitOfWork.bookRepository.Remove(book);

            await _unitOfWork.repositoryManager.SaveChangesAsync(cancellationToken);

        }

     public async Task UpdateAsync(long bookId, BookForUpdateDto bookForUpdateDto, CancellationToken cancellationToken)
        {
            
               var book = await _unitOfWork.bookRepository.GetByIdAsync(bookId, cancellationToken);

            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }

            book.Title = bookForUpdateDto.Title;
            book.IsDeleted = bookForUpdateDto.IsDeleted;
            book.CreatedBy = bookForUpdateDto.CreatedBy;
            book.LastModifiedBy = bookForUpdateDto.LastModifiedBy;
            book.LastModifiedOnUtc = bookForUpdateDto.LastModifiedOnUtc;
            if (bookForUpdateDto.AuthorId==0)
            {
                throw new AuthorNotFoundException(bookForUpdateDto.AuthorId);
            }
            book.AuthorId = bookForUpdateDto.AuthorId;

            await _unitOfWork.repositoryManager.SaveChangesAsync(cancellationToken); 
               
        }
    }
    
}
