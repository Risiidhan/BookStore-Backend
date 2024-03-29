using BookStore.domain.Common;

namespace BookStore.domain.Models
{
    public class Author : BaseModel
    {
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
    }
}