
using AutoMapper;
using BookStore.application.DTO.Book;
using BookStore.application.DTO.Author;
using BookStore.application.DTO.Category;
using BookStore.domain.Models;

namespace BookStore.application.AutoMapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<BookCreateDto, Book>().ReverseMap();
            CreateMap<BookUpdateDto, Book>().ReverseMap();
            CreateMap<BookListDto, Book>().ReverseMap();
            CreateMap<AuthorDto, Author>().ReverseMap();
            CreateMap<AuthorCreateDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CategoryCreateDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
        }
    }
}