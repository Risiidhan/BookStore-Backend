using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.application.Response
{
    public class UserRegisterResponse
    {
        public string Id { get; set; } = null!;
        public bool Success { get; set; }
        public string Message { get; set; } = null!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<string>? Error { get; set; } = null!;
    }
}