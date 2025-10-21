namespace CampusLearnNTG.Models
{
    public class Profile
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;

        public string Major { get; set; } = string.Empty;
        public string YearOfStudy { get; set; } = string.Empty;
        public double GPA { get; set; }
        public List<string> EnrolledCourses { get; set; } = new List<string>();
    }
}
