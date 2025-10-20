using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using CampusLearnNTG.Services;
using CampusLearnNTG.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusLearnNTG.Pages
{
    [Authorize(Roles = "Tutor")]
    public class TutorTopicsModel : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public List<Topic> Topics { get; set; } = new List<Topic>();

        public TutorTopicsModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void OnGet()
        {
            Topics = TopicService.GetTopics();
        }

        // Handler to upload files for a given topic
        public async Task<IActionResult> OnPostUpload(IFormFile[] UploadFiles, string TopicId)
        {
            if (UploadFiles == null || UploadFiles.Length == 0 || string.IsNullOrEmpty(TopicId))
            {
                TempData["UploadMessage"] = "No files selected or invalid topic.";
                return RedirectToPage();
            }

            var savedFiles = new List<string>();
            var topicFolder = Path.Combine(_env.WebRootPath, "uploads", "topics", TopicId);

            if (!Directory.Exists(topicFolder))
                Directory.CreateDirectory(topicFolder);

            foreach (var file in UploadFiles)
            {
                if (file == null || file.Length == 0) continue;

                // sanitize filename and ensure uniqueness
                var safeFileName = Path.GetFileName(file.FileName);
                var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
                var storedFileName = $"{timestamp}_{safeFileName}";
                var filePath = Path.Combine(topicFolder, storedFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                savedFiles.Add(storedFileName);
            }

            if (savedFiles.Any())
            {
                TopicService.AddMaterials(TopicId, savedFiles);
                TempData["UploadMessage"] = $"Uploaded {savedFiles.Count} file(s).";
            }

            return RedirectToPage();
        }

        // Handler to delete a material
        public IActionResult OnPostDeleteMaterial(string TopicId, string Filename)
        {
            if (string.IsNullOrEmpty(TopicId) || string.IsNullOrEmpty(Filename))
                return RedirectToPage();

            var topicFolder = Path.Combine(_env.WebRootPath, "uploads", "topics", TopicId);
            var filePath = Path.Combine(topicFolder, Filename);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            TopicService.RemoveMaterial(TopicId, Filename);

            return RedirectToPage();
        }
    }
}
