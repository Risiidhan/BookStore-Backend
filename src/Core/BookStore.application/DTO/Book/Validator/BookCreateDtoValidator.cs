using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.application.Interface;
using FluentValidation;

namespace BookStore.application.DTO.Book.Validator
{
    public class BookCreateDtoValidator : AbstractValidator<BookCreateDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;
        public BookCreateDtoValidator( 
            IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository)
        {
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            Include(new IBookValidator(_authorRepository,_categoryRepository));
        }
        
    }
}