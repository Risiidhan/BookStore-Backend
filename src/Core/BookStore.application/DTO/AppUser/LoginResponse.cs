using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;

namespace BookStore.application.DTO.AppUser
{
    public class LoginResponse
    {
        public string UserName { get; set; } = null!;
        public string Message { get; set; } = null!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Token { get; set; } = null!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<string>? Error { get; set; } = null!;
    }
}