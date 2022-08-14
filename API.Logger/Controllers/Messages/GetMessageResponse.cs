using API.Logger.Entities;

namespace API.Logger.Controllers.Messages
{
    public class GetMessageResponse
    {
        public List<MessageDto> Messages { get; set; } = new List<MessageDto>();
        public int Count { get; set; } = 2;
    }
}
