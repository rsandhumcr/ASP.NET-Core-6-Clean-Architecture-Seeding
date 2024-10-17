using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using CompanyNameSpace.ProjectName.Domain.Entities;

namespace CompanyNameSpace.ProjectName.Persistence.Repositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(ProjectNameDbContext dbContext) : base(dbContext)
    {
    }

    public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
    {
        var matches = DbContext.Events.Any(e => e.Name.Equals(name) && e.Date.Date.Equals(eventDate.Date));
        return Task.FromResult(matches);
    }
}