using BookStore.application.DTO.Common;

namespace BookStore.application.DTO.Book
{
    public class BookListDto : BaseDto
    {
        public int CategoryID { get; set; }
        public int Price { get; set; }
    }
}