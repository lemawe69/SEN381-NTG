using CampusLearnNTG.Services;
using Microsoft.AspNetCore.Mvc;

namespace CampusLearnNTG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;

        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody] ChatRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Message))
                return BadRequest("Message cannot be empty.");

            var reply = await _chatService.GetChatResponse(request.Message);
            return Ok(new { reply });
        }
    }

    public class ChatRequest
    {
        public string Message { get; set; } = "";
    }
}
