using BookStore.application.DTO.Author;
using BookStore.application.DTO.Category;
using BookStore.application.DTO.Common;


namespace BookStore.application.DTO.Book
{
    public class BookDto : BaseDto
    {
        public int Price { get; set; }
        public int QuantityAvailable { get; set; }
        public AuthorDto Author { get; set; } = null!;
        public CategoryDto Category { get; set; } = null!;
    }
}