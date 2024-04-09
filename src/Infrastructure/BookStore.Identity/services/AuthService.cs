using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookStore.application.DTO.AppUser;
using BookStore.application.DTO.JWT;
using BookStore.application.Interface;
using BookStore.application.Response;
using BookStore.domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


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
        public async Task<string> GenerateToken(AppUser user)
        {
            if(user.UserName == null || user.Email == null)
                throw new Exception("No credenials");

            var roles = await _userManager.GetRolesAsync(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Value.Key);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            // Add roles to the claims
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var identity = new ClaimsIdentity(claims);

            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.Value.DurationInMinutes),
                SigningCredentials = creds,
                Issuer = _jwtSettings.Value.Issuer,
                Audience = _jwtSettings.Value.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<LoginResponse> login(LoginRequestDto request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null)
                throw new Exception($"User with {request.Username} not found.");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
                throw new Exception($"Credentials for '{request.Username} aren't valid'.");

            var token = GenerateToken(user);

            var res = new LoginResponse();
            if (token == null)
            {
                res.UserName = request.Username;
                res.Message = "Failed to login";
                res.Token = null;
            }
            else
            {
                res.UserName = request.Username;
                res.Message = "logged in Successfully!";
                res.Token = token.ToString();
            }
            return res;
        }

        public async Task<UserRegisterResponse> Register(RegisterUserDto registerUserDto)
        {
            var userExists = await _userManager.FindByNameAsync(registerUserDto.Username);
            if (userExists == null)
                throw new Exception("Username Already Exists");

            var emailExists = await _userManager.FindByEmailAsync(registerUserDto.Email);
            if (emailExists == null)
                throw new Exception("Email Already Exists");

            var appUser = new AppUser
            {
                Email = registerUserDto.Email,
                UserName = registerUserDto.Username,
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerUserDto.Password);
            var res = new UserRegisterResponse();
            if (createdUser.Succeeded)
            {
                var roleRes = await _userManager.AddToRolesAsync(appUser, registerUserDto.Roles);
                if (roleRes.Succeeded)
                {
                    res.Id = appUser.Id;
                    res.Success = true;
                    res.Message = "Create User Successfully";
                }
                else
                {
                    res.Id = appUser.Id;
                    res.Success = false;
                    res.Message = "Failed to Assign roles";
                    res.Error = roleRes.Errors.Select(error => error.Description).ToList();
                }
            }
            else
            {
                res.Id = appUser.Id;
                res.Success = false;
                res.Message = "Failed to Create User";
                res.Error = createdUser.Errors.Select(error => error.Description).ToList();
            }

            return res;
        }
    }
}