using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CampusLearnNTG.Data;
using CampusLearnNTG.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusLearnNTG.Pages
{
    public class MessagesModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public MessagesModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public PrivateMessage Message { get; set; }

        public List<User> Contacts { get; set; } = new();
        public List<PrivateMessage> Conversation { get; set; } = new();
        public User? SelectedContact { get; set; }

        public int CurrentUserId => 1; // Replace with session or auth ID

        public async Task OnGetAsync(int? contactId)
        {
            Contacts = await _db.Users
                .Where(u => u.Id != CurrentUserId)
                .ToListAsync();

            if (contactId.HasValue)
            {
                SelectedContact = await _db.Users.FindAsync(contactId);
                if (SelectedContact != null)
                {
                    Conversation = await _db.PrivateMessages
                        .Where(m => (m.SenderId == CurrentUserId && m.ReceiverId == contactId)
                                 || (m.SenderId == contactId && m.ReceiverId == CurrentUserId))
                        .OrderBy(m => m.SentAt)
                        .ToListAsync();

                    Message = new PrivateMessage
                    {
                        ReceiverId = SelectedContact.Id,
                        SenderId = CurrentUserId
                    };
                }
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Message.SenderId = CurrentUserId;
            Message.SentAt = DateTime.Now;

            if (string.IsNullOrWhiteSpace(Message.Content))
            {
                return RedirectToPage(new { contactId = Message.ReceiverId });
            }

            _db.PrivateMessages.Add(Message);
            await _db.SaveChangesAsync();

            return RedirectToPage(new { contactId = Message.ReceiverId });
        }
    }
}
