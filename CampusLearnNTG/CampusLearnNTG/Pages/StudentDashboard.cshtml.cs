using CampusLearnNTG.Services;
using CampusLearnNTG.Models;

public List<Topic> Topics { get; set; } = new List<Topic>();

public void OnGet()
{
    Topics = TopicService.GetTopics();
}

public IActionResult OnPostCreateTopic(string TopicTitle, string TopicDescription)
{
    TopicService.AddTopic(new Topic
    {
        Title = TopicTitle,
        Description = TopicDescription,
        CreatedBy = User.Identity?.Name ?? "Student"
    });

    return RedirectToPage();
}
