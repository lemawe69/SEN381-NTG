﻿namespace CampusLearnNTG.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Student"; // Student, Tutor, Admin
        public string Status { get; set; } = "Active";
    }
}
