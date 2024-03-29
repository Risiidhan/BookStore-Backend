using BookStore.application.DTO.Author;
using BookStore.application.DTO.Category;
using BookStore.application.DTO.Common;


namespace BookStore.application.DTO.Book
{
    public class BookDto : BaseDto
    {
        public int AuthorID { get; set; }
        public AuthorDto AuthorDto { get; set; } = null!;
        public int CategoryID { get; set; }
        public CategoryDto CategoryDto { get; set; } = null!;
        public int Price { get; set; }
        public int QuantityAvailable { get; set; }
    }
}