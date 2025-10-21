using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace CampusLearnNTG.Pages
{
    public class ProfileModel : PageModel
    {
        public string FullName => $"{FirstName} {LastName}";
        public string UserInitials => $"{FirstName[0]}{LastName[0]}";
        public string StudentID { get; set; } = "CL-STU-0293";
        public string Major { get; set; } = "Computer Science";
        public string EnrollmentYear { get; set; } = "2023";

        // Personal Info
        public string FirstName { get; set; } = "John";
        public string LastName { get; set; } = "Doe";
        public string Email { get; set; } = "john.doe@campuslearn.ac.za";
        public string Phone { get; set; } = "+27 (0)79 123 4567";
        public DateTime DOB { get; set; } = new DateTime(2004, 07, 21);
        public string Address { get; set; } = "123 University Ave, Campus City, ZA 0002";

        // Academic Info
        public string YearOfStudy { get; set; } = "3rd Year";
        public double GPA { get; set; } = 3.85;
        public List<string> EnrolledCourses { get; set; } = new()
        {
            "Advanced Algorithms (CS407)",
            "Database Systems (CS306)",
            "Web Development (CS310)",
            "Artificial Intelligence (CS412)"
        };

        public void OnGet() { }
    }
}
