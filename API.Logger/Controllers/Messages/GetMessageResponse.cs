using API.Logger.Entities;

namespace API.Logger.Controllers.Messages
{
    public class GetMessageResponse
    {
        public IEnumerable<MessageDto> Messages = new List<MessageDto>();

    }
}
