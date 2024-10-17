using CompanyNameSpace.ProjectName.Domain.Entities;

namespace CompanyNameSpace.ProjectName.Application.Contracts.Persistence
{
    public interface IEntityOneRepository : IAsyncRepository<EntityOne>
    {
        Task<List<EntityOne>> GetPagedEntityOneList(int page, int size);
    }
}
