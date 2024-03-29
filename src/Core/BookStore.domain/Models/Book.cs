using BookStore.domain.Common;

namespace BookStore.domain.Models
{
    public class Book : BaseModel
    {
        public int AuthorID { get; set; }
        public Author Author {get; set;} = null!;
        public int CategoryID { get; set; }
        public Category Category { get; set; } = null!;
        public int Price { get; set; }
        public int QuantityAvailable { get; set; }

    }
}