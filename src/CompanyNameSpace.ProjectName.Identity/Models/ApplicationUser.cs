using Microsoft.AspNetCore.Identity;

namespace CompanyNameSpace.ProjectName.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}