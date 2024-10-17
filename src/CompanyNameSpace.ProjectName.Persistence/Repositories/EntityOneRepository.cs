using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using CompanyNameSpace.ProjectName.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyNameSpace.ProjectName.Persistence.Repositories;

public class EntityOneRepository : BaseRepository<EntityOne>, IEntityOneRepository
{
    public EntityOneRepository(ProjectNameDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<EntityOne>> GetPagedEntityOneList(int page, int size)
    {
        return await DbContext.EntityOnes
            .Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
    }
}