using Microsoft.AspNetCore.Mvc;
using CampusLearnNTG.Data;
using CampusLearnNTG.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusLearnNTG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public MessageController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("{userId}/{contactId}")]
        public async Task<IActionResult> GetConversation(int userId, int contactId)
        {
            var messages = await _db.PrivateMessages
                .Where(m => (m.SenderId == userId && m.ReceiverId == contactId)
                         || (m.SenderId == contactId && m.ReceiverId == userId))
                .OrderBy(m => m.SentAt)
                .ToListAsync();

            return Ok(messages);
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody] PrivateMessage message)
        {
            if (string.IsNullOrWhiteSpace(message.Content))
                return BadRequest("Message cannot be empty.");

            _db.PrivateMessages.Add(message);
            await _db.SaveChangesAsync();
            return Ok(message);
        }

        [HttpGet("contacts/{userId}")]
        public async Task<IActionResult> GetContacts(int userId)
        {
            var contacts = await _db.Users
                .Where(u => u.Id != userId)
                .Select(u => new { u.Id, u.FullName, u.Role })
                .ToListAsync();

            return Ok(contacts);
        }
    }
}
