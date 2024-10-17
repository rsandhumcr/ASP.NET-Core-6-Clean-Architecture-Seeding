using CompanyNameSpace.ProjectName.Domain.Entities;

namespace CompanyNameSpace.ProjectName.Application.Contracts.Persistence;

public interface IEntityOneRepository : IAsyncRepository<EntityOne>
{
    Task<IReadOnlyList<EntityOne>> GetPagedEntityOneList(int page, int size);
}