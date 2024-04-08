
using System.ComponentModel.DataAnnotations;

namespace BookStore.application.DTO.AppUser
{
    public class RegisterUserDto
    {
        [Required]
        public string? Username { get; set; }
        
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        
        [Required]
        public string? Password { get; set; }

        public string[] Roles { get; set; } = [];
    }
}