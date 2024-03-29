namespace BookStore.application.DTO.Author
{
    public class AuthorUpdateDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
    }
}