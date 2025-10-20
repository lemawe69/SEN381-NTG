using Microsoft.AspNetCore.Mvc;
using CampusLearnNTG.Data;
using CampusLearnNTG.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusLearnNTG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ForumController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("posts")]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _db.ForumPosts
                .Include(p => p.Author)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return Ok(posts);
        }

        [HttpPost("posts")]
        public async Task<IActionResult> CreatePost([FromBody] ForumPost post)
        {
            if (string.IsNullOrWhiteSpace(post.Content))
                return BadRequest("Post content required.");

            _db.ForumPosts.Add(post);
            await _db.SaveChangesAsync();
            return Ok(post);
        }

        [HttpPost("reply/{postId}")]
        public async Task<IActionResult> AddReply(int postId, [FromBody] ForumReply reply)
        {
            var post = await _db.ForumPosts.FindAsync(postId);
            if (post == null)
                return NotFound();

            reply.PostId = postId;
            _db.ForumReplies.Add(reply);
            await _db.SaveChangesAsync();
            return Ok(reply);
        }

        [HttpPost("upvote/{postId}")]
        public async Task<IActionResult> Upvote(int postId)
        {
            var post = await _db.ForumPosts.FindAsync(postId);
            if (post == null)
                return NotFound();

            post.Upvotes++;
            await _db.SaveChangesAsync();
            return Ok(post.Upvotes);
        }
    }
}
