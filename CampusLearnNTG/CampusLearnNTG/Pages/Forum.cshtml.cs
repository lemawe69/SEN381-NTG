using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CampusLearnNTG.Pages
{
    public class ForumModel : PageModel
    {
        public List<ThreadModel> Threads { get; set; }
        public List<string> TrendingTopics { get; set; }
        public List<string> MyThreads { get; set; }

        public void OnGet()
        {
            Threads = new List<ThreadModel>
            {
                new ThreadModel { Author = "Alex Johnson", AuthorInitial = "A", Title = "Optimal Study Techniques for Final Exams", Content = "Sharing study techniques that worked well for me during finals...", Replies = 22, Views = 590, TimeAgo = "55 min ago", LastActive = "Just now", Pinned = true },
                new ThreadModel { Author = "Maria Rodriguez", AuthorInitial = "M", Title = "Seeking Group for 'Advanced Calculus' Project", Content = "Looking for classmates to collaborate on the project...", Replies = 10, Views = 210, TimeAgo = "1 hr ago", LastActive = "10 min ago" },
                new ThreadModel { Author = "Prof. David Lee", AuthorInitial = "D", Title = "Tips for Effective Presentation Skills", Content = "Here are a few insights for better delivery...", Replies = 18, Views = 370, TimeAgo = "2 hrs ago", LastActive = "15 min ago" },
                new ThreadModel { Author = "Sarah Chen", AuthorInitial = "S", Title = "Troubleshooting: Python Environment Setup", Content = "Having issues with setting up Python environment...", Replies = 9, Views = 220, TimeAgo = "3 hrs ago", LastActive = "1 hr ago" },
                new ThreadModel { Author = "Student Union", AuthorInitial = "U", Title = "Upcoming Student Social Event: Board Game Night!", Content = "Excited to announce our social event happening this Friday...", Replies = 7, Views = 410, TimeAgo = "3 hrs ago", LastActive = "2 hrs ago" }
            };

            TrendingTopics = new List<string>
            {
                "AI Ethics in Research",
                "Quantum Computing Basics",
                "Career Fair Preparation",
                "Mental Health Awareness",
                "Sustainable Engineering Solutions"
            };

            MyThreads = new List<string>
            {
                "Project Management Software",
                "Literature Review Strategies",
                "Internship Opportunities"
            };
        }

        public class ThreadModel
        {
            public string Author { get; set; }
            public string AuthorInitial { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public int Replies { get; set; }
            public int Views { get; set; }
            public string TimeAgo { get; set; }
            public string LastActive { get; set; }
            public bool Pinned { get; set; }
        }
    }
}
