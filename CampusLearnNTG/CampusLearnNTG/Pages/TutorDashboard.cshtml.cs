using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Tutor")]
public class TutorDashboardModel : PageModel
{
    public void OnGet() { }
}
