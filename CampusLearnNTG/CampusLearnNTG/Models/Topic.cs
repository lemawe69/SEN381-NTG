using System;
using System.Collections.Generic;

namespace CampusLearnNTG.Models
{
    public class Topic
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); // unique id
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }  // student email/name
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Files uploaded by tutors for this topic (store file name only, path is wwwroot/uploads/topics/{Id}/)
        public List<string> Materials { get; set; } = new List<string>();
    }
}
