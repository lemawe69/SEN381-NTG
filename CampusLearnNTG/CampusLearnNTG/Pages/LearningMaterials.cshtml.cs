using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CampusLearnNTG.Pages
{
    public class LearningMaterialsModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        public List<string> FileList { get; set; } = new List<string>();

        [BindProperty]
        public IFormFile UploadFile { get; set; }

        public LearningMaterialsModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public void OnGet()
        {
            var uploadPath = Path.Combine(_environment.WebRootPath, "uploads");
            if (Directory.Exists(uploadPath))
            {
                FileList = Directory.GetFiles(uploadPath).Select(Path.GetFileName).ToList();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (UploadFile != null)
            {
                var uploadPath = Path.Combine(_environment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                var filePath = Path.Combine(uploadPath, UploadFile.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await UploadFile.CopyToAsync(fileStream);
                }
            }

            return RedirectToPage();
        }
    }
}
