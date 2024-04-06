namespace BookStore.application.DTO.Book
{
    public class IBookValidatorDto
    {

        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public int Price { get; set; }
        public string Name { get; set; } = null!;
        public int QuantityAvailable { get; set; }
    }
}