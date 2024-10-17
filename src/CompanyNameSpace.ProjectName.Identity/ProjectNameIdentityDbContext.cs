using CompanyNameSpace.ProjectName.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompanyNameSpace.ProjectName.Identity;

public class ProjectNameIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public ProjectNameIdentityDbContext()
    {
    }

    public ProjectNameIdentityDbContext(DbContextOptions<ProjectNameIdentityDbContext> options) : base(options)
    {
    }
}
/*
Package Nuget Console
Select correct project in drop

Add-Migration InitialIdentity -Context ProjectNameIdentityDbContext
*/