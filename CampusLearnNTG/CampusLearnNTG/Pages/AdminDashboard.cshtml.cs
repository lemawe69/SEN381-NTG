using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin")]
public class AdminDashboardModel : PageModel
{
    public void OnGet() { }
}
