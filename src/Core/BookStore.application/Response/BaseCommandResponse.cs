
namespace BookStore.application.Response
{
    public class BaseCommandResponse
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public List<string> Error { get; set; } = null!;
    }
}