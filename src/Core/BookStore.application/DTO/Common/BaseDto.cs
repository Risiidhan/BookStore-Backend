namespace BookStore.application.DTO.Common
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}