using BookStore.application.DTO.Common;

namespace BookStore.application.DTO.Author
{
    public class AuthorDto : BaseDto
    {
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
    }
}