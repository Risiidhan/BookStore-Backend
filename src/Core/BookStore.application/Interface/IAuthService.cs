using BookStore.application.DTO.AppUser;
using BookStore.application.Response;
using BookStore.domain.Models;


namespace BookStore.application.Interface
{
    public interface IAuthService
    {
        Task<LoginResponse> login(LoginRequestDto request);
        Task<UserRegisterResponse> Register(RegisterUserDto registerUserDto);
        Task<string> GenerateToken(AppUser user);
    }
}