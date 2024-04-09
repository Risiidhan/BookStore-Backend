
using System.ComponentModel.DataAnnotations;

namespace BookStore.application.DTO.AppUser
{
    public class RegisterUserDto
    {
        [Required]
        public string Username { get; set; } = null!;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        
        [Required]
        public string Password { get; set; } = null!;

        public string[] Roles { get; set; } = [];
    }
}