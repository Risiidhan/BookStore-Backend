using System.ComponentModel.DataAnnotations;

namespace BookStore.application.DTO.AppUser
{
    public class LoginRequestDto 
    {
        [Required]
        public string Username {get;set;} = null!;

        [Required]
        public string Password {get;set;} = null!;
    }
}