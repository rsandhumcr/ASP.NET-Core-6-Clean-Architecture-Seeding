using CompanyNameSpace.ProjectName.Domain.Entities.Sales;

namespace CompanyNameSpace.ProjectName.Application.Contracts.Persistence.Sales;

public interface IProductRepository : IAsyncRepository<Product>
{
    Task<IReadOnlyList<Product>> GetByCodes(List<string> codes);
}