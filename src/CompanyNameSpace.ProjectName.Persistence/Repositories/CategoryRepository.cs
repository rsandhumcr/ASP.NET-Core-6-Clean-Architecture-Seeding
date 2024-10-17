using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using CompanyNameSpace.ProjectName.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyNameSpace.ProjectName.Persistence.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ProjectNameDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
    {
        var allCategories = await DbContext.Categories.Include(x => x.Events).ToListAsync();
        if (!includePassedEvents) allCategories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
        return allCategories;
    }
}