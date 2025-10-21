using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CampusLearnNTG.Pages
{
    public class SignupModel : PageModel
    {
        [BindProperty]
        public StudentSignup Student { get; set; } = new();

        [BindProperty]
        public TutorSignup Tutor { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPostStudentSignup()
        {
            if (!ModelState.IsValid)
                return Page();

            // TODO: Save Student to DB (PostgreSQL)
            // Example: INSERT INTO Students (...)
            return RedirectToPage("/Login");
        }

        public IActionResult OnPostTutorSignup()
        {
            if (!ModelState.IsValid)
                return Page();

            // TODO: Save Tutor to DB (PostgreSQL)
            return RedirectToPage("/Login");
        }

        // Models
        public class StudentSignup
        {
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string? StudentId { get; set; }
        }

        public class TutorSignup
        {
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string Expertise { get; set; }
        }
    }
}
