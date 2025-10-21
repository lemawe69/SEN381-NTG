using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace CampusLearnNTG.Pages
{
    public class AdminDashboardModel : PageModel
    {
        public List<UserModel> Users { get; set; } = new();
        public List<ForumPostModel> ForumPosts { get; set; } = new();
        public List<LearningMaterialModel> LearningMaterials { get; set; } = new();
        public AnalyticsModel Analytics { get; set; } = new();
        public SettingsModel Settings { get; set; } = new();
        public List<NotificationModel> Notifications { get; set; } = new();

        public void OnGet()
        {
            // mock users
            Users = new List<UserModel>
            {
                new() { Id = 1001, Name = "Alex Johnson", Email = "alex@campus.com", Role = "Student", Status = "Active" },
                new() { Id = 1002, Name = "Dr. Emily White", Email = "emily@campus.com", Role = "Tutor", Status = "Active" },
                new() { Id = 1003, Name = "Ben Carter", Email = "ben@campus.com", Role = "Student", Status = "Pending" },
                new() { Id = 1004, Name = "Admin User", Email = "admin@campus.com", Role = "Admin", Status = "Active" }
            };

            // mock posts / materials
            ForumPosts = new List<ForumPostModel>
            {
                new() { Title = "Question about Calculus", Author="Mary P.", SubmittedAt = DateTime.Now.AddDays(-1) },
                new() { Title = "Feedback on Session #104", Author="Lucas R.", SubmittedAt = DateTime.Now.AddDays(-2) },
                new() { Title = "Bug: material download", Author="QA Team", SubmittedAt = DateTime.Now.AddDays(-3) }
            };

            LearningMaterials = new List<LearningMaterialModel>
            {
                new() { Title = "Algebra Basics Lecture Notes", Type = "PDF", UploadedAt = DateTime.Now.AddDays(-4) },
                new() { Title = "Advanced Physics Quiz", Type = "Quiz", UploadedAt = DateTime.Now.AddDays(-6) },
                new() { Title = "Chemistry Lab Guide", Type = "DOCX", UploadedAt = DateTime.Now.AddDays(-10) }
            };

            // analytics (mock)
            Analytics = new AnalyticsModel
            {
                TotalUsers = 1234,
                ActiveUsers = 189,
                Posts = 58,
                Uploads = 12,
                ActivityLabels = new List<string> { "Day 1", "Day 2", "Day 3", "Day 4", "Day 5", "Day 6", "Day 7" },
                ActivityData = new List<int> { 90, 100, 110, 95, 120, 130, 125 },
                UsageLabels = new List<string> { "Web", "Mobile", "API", "Other" },
                UsageData = new List<int> { 400, 250, 150, 60 }
            };

            Settings = new SettingsModel
            {
                SiteTitle = "CampusLearn",
                AdminEmail = "admin@campus.com",
                RegistrationOpen = true
            };

            Notifications = new List<NotificationModel>
            {
                new() { Title = "New user registered", Message = "John Doe just signed up", TimeAgo = "2 hours ago" },
                new() { Title = "Flagged post", Message = "Post in Calculus flagged for review", TimeAgo = "6 hours ago" },
                new() { Title = "Backup complete", Message = "Daily backup finished without errors", TimeAgo = "1 day ago" }
            };
        }

        // nested types
        public class UserModel { public int Id { get; set; } public string Name { get; set; } public string Email { get; set; } public string Role { get; set; } public string Status { get; set; } }
        public class ForumPostModel { public string Title { get; set; } public string Author { get; set; } public DateTime SubmittedAt { get; set; } }
        public class LearningMaterialModel { public string Title { get; set; } public string Type { get; set; } public DateTime UploadedAt { get; set; } }
        public class AnalyticsModel
        {
            public int TotalUsers { get; set; }
            public int ActiveUsers { get; set; }
            public int Posts { get; set; }
            public int Uploads { get; set; }
            public List<string> ActivityLabels { get; set; } = new();
            public List<int> ActivityData { get; set; } = new();
            public List<string> UsageLabels { get; set; } = new();
            public List<int> UsageData { get; set; } = new();
        }
        public class SettingsModel { public string SiteTitle { get; set; } public string AdminEmail { get; set; } public bool RegistrationOpen { get; set; } }
        public class NotificationModel { public string Title { get; set; } public string Message { get; set; } public string TimeAgo { get; set; } }
    }
}
