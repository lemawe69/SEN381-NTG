using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace CampusLearnNTG.Pages
{
    public class StudentDashboardModel : PageModel
    {
        public StudentModel Student { get; set; }
        public List<SessionModel> UpcomingSessions { get; set; }
        public List<MaterialModel> LearningMaterials { get; set; }
        public List<MessageModel> RecentMessages { get; set; }

        public void OnGet()
        {
            // Temporary mock data (replace later with REST API call)
            Student = new StudentModel
            {
                FirstName = "Alex",
                LastName = "Johnson",
                StudentId = "ST12345",
                Status = "Active",
                Progress = 75
            };

            UpcomingSessions = new List<SessionModel>
            {
                new SessionModel { Title = "Advanced Calculus", Instructor = "Dr. Emily White", Date = DateTime.Now.AddDays(1).AddHours(2) },
                new SessionModel { Title = "Literary Analysis", Instructor = "Prof. Ben Carter", Date = DateTime.Now.AddDays(2).AddHours(3) },
                new SessionModel { Title = "Quantum Physics I", Instructor = "Dr. Lena Khan", Date = DateTime.Now.AddDays(3).AddHours(1) }
            };

            LearningMaterials = new List<MaterialModel>
            {
                new MaterialModel { Title = "Calculus III Notes - Chapter 5", Type = "PDF" },
                new MaterialModel { Title = "Shakespeare Sonnets Analysis", Type = "Handout" },
                new MaterialModel { Title = "Physics Equations - Cheat Sheet", Type = "PDF" }
            };

            RecentMessages = new List<MessageModel>
            {
                new MessageModel { Sender = "Dr. Emily White", Content = "Reminder for tomorrow's session.", TimeAgo = "2 hours ago" },
                new MessageModel { Sender = "Study Group Physics", Content = "Anyone free to meet for the project?", TimeAgo = "30 mins ago" },
                new MessageModel { Sender = "Prof. Ben Carter", Content = "Your essay draft feedback is ready.", TimeAgo = "1 day ago" }
            };
        }

        // --- Models ---
        public class StudentModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string StudentId { get; set; }
            public string Status { get; set; }
            public int Progress { get; set; }
        }

        public class SessionModel
        {
            public string Title { get; set; }
            public string Instructor { get; set; }
            public DateTime Date { get; set; }
        }

        public class MaterialModel
        {
            public string Title { get; set; }
            public string Type { get; set; }
        }

        public class MessageModel
        {
            public string Sender { get; set; }
            public string Content { get; set; }
            public string TimeAgo { get; set; }
        }
    }
}
