using CompanyNameSpace.ProjectName.Application.Contracts.Persistence.Sales;
using CompanyNameSpace.ProjectName.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;

namespace CompanyNameSpace.ProjectName.Persistence.Repositories.Sales;

public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(ProjectNameDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Department?> GetByName(string name)
    {
        
        return await DbContext.Departments.FirstOrDefaultAsync(e => e.Name == name);
    }

    public async Task<IReadOnlyList<Department>> GetByNames(List<string> names)
    {
        var matches = await DbContext.Departments
            .Where(e => names.Contains(e.Name))
            .ToListAsync();
        return matches;
    }
}