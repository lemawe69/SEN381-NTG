using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CampusLearnNTG.Pages
{
    public class FeedbackModel : PageModel
    {
        [BindProperty]
        public string FeedbackCategory { get; set; }

        [BindProperty]
        public string FeedbackMessage { get; set; }

        [BindProperty]
        public int Satisfaction { get; set; }

        [BindProperty]
        public bool SubmitAnonymously { get; set; }

        public void OnGet()
        {
            Satisfaction = 5; // default slider position
        }

        public IActionResult OnPost()
        {
            // Here you could save feedback to the database or send an email
            TempData["SuccessMessage"] = "Thank you for your feedback!";
            return RedirectToPage("/Feedback");
        }
    }
}
