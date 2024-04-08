using System.IdentityModel.Tokens.Jwt;
using BookStore.application.DTO.AppUser;
using BookStore.application.DTO.JWT;
using BookStore.application.Interface;
using BookStore.application.Response;
using BookStore.domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;


namespace BookStore.Identity.services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IOptions<JwtSettings> _jwtSettings;

        public AuthService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IOptions<JwtSettings> jwtSettings
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings;
        }
        public Task<JwtSecurityToken> GenerateToken(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponse> login(LoginRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseCommandResponse> Register(RegisterUserDto registerUserDto)
        {
            throw new NotImplementedException();
        }
    }
}