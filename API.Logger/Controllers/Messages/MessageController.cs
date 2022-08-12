using API.Logger.DataStorage;
using API.Logger.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace API.Logger.Controllers.Messages
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : Controller
    {
        public MongoDbContext _dbContext { get; }

        public MessageController(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult AddMessage([FromBody] NewMessageDto newMessageDto)
        {
            Message message = new Message()
            {
                Description = newMessageDto.Description,
                Title = newMessageDto.Title,
            };

            _dbContext.GetMessageCollection().InsertOne(message);
            return Ok();
        }

        [HttpGet]
        public GetMessageResponse GetMessages([FromBody] GetMessageRequest request)
        {
            var messages = _dbContext.GetMessageCollection().Find(m => true)
                .ToList()
                .Select(m => new MessageDto
                {
                    Description = m.Description,
                    Title = m.Title,
                });

            return new GetMessageResponse() { Messages = messages };
        }
    }
}
