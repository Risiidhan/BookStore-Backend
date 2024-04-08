using BookStore.application.DTO.AppUser;
using BookStore.application.Response;
using BookStore.domain.Models;
using System.IdentityModel.Tokens.Jwt;


namespace BookStore.application.Interface
{
    public interface IAuthService
    {
        Task<LoginResponse> login(LoginRequestDto request);
        Task<BaseCommandResponse> Register(RegisterUserDto registerUserDto);
        Task<JwtSecurityToken> GenerateToken(AppUser user);
    }
}