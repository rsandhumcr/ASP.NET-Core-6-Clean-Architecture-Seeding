using CompanyNameSpace.ProjectName.Domain.Entities.Sales;

namespace CompanyNameSpace.ProjectName.Application.Contracts.Persistence.Sales;

public interface IDepartmentRepository : IAsyncRepository<Department>
{
    Task<Department?> GetByName(string name);
    Task<IReadOnlyList<Department>> GetByNames(List<string> names);
}