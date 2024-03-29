
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
            CreateMap<BookDto,Book>().ReverseMap();
            CreateMap<BookListDto,Book>().ReverseMap();
            CreateMap<AuthorDto,Author>().ReverseMap();
            CreateMap<CategoryDto,Category>().ReverseMap();
        }
    }
}