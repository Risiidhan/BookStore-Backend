using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.application.DTO.AppUser
{
    public class LoginResponse
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}