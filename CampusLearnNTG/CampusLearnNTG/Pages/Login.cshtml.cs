using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CampusLearnNTG.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty] public string Username { get; set; } = "";
        [BindProperty] public string Password { get; set; } = "";
        public string? ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            // Demo logic: redirect based on username
            if (Username == "student") return RedirectToPage("/StudentDashboard");
            if (Username == "lecturer") return RedirectToPage("/LecturerDashboard");
            if (Username == "admin") return RedirectToPage("/AdminDashboard");

            ErrorMessage = "Invalid credentials";
            return Page();
        }
    }
}
