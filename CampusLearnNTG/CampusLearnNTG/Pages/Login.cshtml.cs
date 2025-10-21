using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CampusLearnNTG.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public StudentLoginModel Student { get; set; } = new();

        [BindProperty]
        public TutorLoginModel Tutor { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPostStudentLogin()
        {
            if (!ModelState.IsValid)
                return Page();

            // TODO: Validate credentials with PostgreSQL
            // If successful:
            return RedirectToPage("/StudentDashboard");

            // Else: Add ModelState error
            // ModelState.AddModelError(string.Empty, "Invalid credentials.");
            // return Page();
        }

        public IActionResult OnPostTutorLogin()
        {
            if (!ModelState.IsValid)
                return Page();

            // TODO: Validate credentials with PostgreSQL
            return RedirectToPage("/TutorDashboard");
        }

        public class StudentLoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class TutorLoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
