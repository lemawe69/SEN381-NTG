using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CampusLearnNTG.Pages
{
    public class CoursesModel : PageModel
    {
        public List<Course> Courses { get; set; }

        public void OnGet()
        {
            Courses = new List<Course>
            {
                new Course { Title = "Introduction to Computer Science", Description = "A foundational course covering the basics of programming and algorithms.", Level = "Beginner", ImageUrl = "/images/course1.jpg" },
                new Course { Title = "Advanced Calculus", Description = "Dive into complex mathematical theories and advanced problem-solving.", Level = "Advanced", ImageUrl = "/images/course2.jpg" },
                new Course { Title = "Graphic Design Fundamentals", Description = "Learn the principles of effective visual communication.", Level = "Intermediate", ImageUrl = "/images/course3.jpg" },
                new Course { Title = "Business Strategy & Management", Description = "Explore business models and leadership techniques.", Level = "Intermediate", ImageUrl = "/images/course4.jpg" },
                new Course { Title = "World History: Ancient Civilizations", Description = "Understand the origins of civilization and cultural evolution.", Level = "Beginner", ImageUrl = "/images/course5.jpg" },
                new Course { Title = "Introduction to Spanish Language", Description = "Learn conversational Spanish and essential grammar.", Level = "Beginner", ImageUrl = "/images/course6.jpg" },
                new Course { Title = "Foundations of Philosophy", Description = "Examine philosophical ideas and reasoning techniques.", Level = "Advanced", ImageUrl = "/images/course7.jpg" },
                new Course { Title = "Organic Chemistry II", Description = "Advanced study of organic compounds and synthesis.", Level = "Advanced", ImageUrl = "/images/course8.jpg" },
                new Course { Title = "Art Appreciation", Description = "Explore art history and interpretation through visual analysis.", Level = "Beginner", ImageUrl = "/images/course9.jpg" },
            };
        }

        public class Course
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Level { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}
