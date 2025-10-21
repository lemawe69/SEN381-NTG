using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace CampusLearnNTG.Pages
{
    public class TutorDashboardModel : PageModel
    {
        public TutorModel Tutor { get; set; }
        public List<SessionModel> UpcomingSessions { get; set; }
        public List<ResourceModel> UploadedResources { get; set; }
        public int UnreadMessages { get; set; }
        public string ForumActivity { get; set; }

        public void OnGet()
        {
            // Mock data (replace with REST API calls later)
            Tutor = new TutorModel
            {
                FirstName = "Alex",
                LastName = "Johnson",
                Status = "Active",
                Students = 125,
                Courses = 8,
                Hours = 320,
                Rating = 4.9
            };

            UpcomingSessions = new List<SessionModel>
            {
                new SessionModel { Title = "Algebra I Review", StudentName = "Alice Smith", Date = DateTime.Now.AddDays(1).AddHours(2) },
                new SessionModel { Title = "Calculus II Prep", StudentName = "Bob Johnson", Date = DateTime.Now.AddDays(2).AddHours(4) },
                new SessionModel { Title = "Data Structures Intro", StudentName = "Charlie Brown", Date = DateTime.Now.AddDays(3).AddHours(3) }
            };

            UploadedResources = new List<ResourceModel>
            {
                new ResourceModel { Title = "Algebra Worksheet", Type = "PDF", Size = "2.5 MB", UploadDate = DateTime.Now.AddDays(-1) },
                new ResourceModel { Title = "Physics Notes Ch 1", Type = "DOCX", Size = "1.2 MB", UploadDate = DateTime.Now.AddDays(-2) },
                new ResourceModel { Title = "Programming Guide", Type = "PDF", Size = "3.1 MB", UploadDate = DateTime.Now.AddDays(-3) }
            };

            UnreadMessages = 7;
            ForumActivity = "2 new posts in 'General Discussion'";
        }

        // ---------- Models ----------
        public class TutorModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Status { get; set; }
            public int Students { get; set; }
            public int Courses { get; set; }
            public int Hours { get; set; }
            public double Rating { get; set; }
        }

        public class SessionModel
        {
            public string Title { get; set; }
            public string StudentName { get; set; }
            public DateTime Date { get; set; }
        }

        public class ResourceModel
        {
            public string Title { get; set; }
            public string Type { get; set; }
            public string Size { get; set; }
            public DateTime UploadDate { get; set; }
        }
    }
}
