namespace API.Logger.Entities
{
    public class Message : EntityBase
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public LogLevel LogLevel { get; set; }
        public string? Key { get; set; }
    }
}
