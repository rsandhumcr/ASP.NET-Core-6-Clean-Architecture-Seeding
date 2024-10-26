using CompanyNameSpace.ProjectName.Domain.Entities.Sales;

namespace CompanyNameSpace.ProjectName.Application.Contracts.Persistence.Sales;

public interface ISaleRepository : IAsyncRepository<Sale>
{
    Task<IReadOnlyList<Sale>> GetBySalesDatesAndProductId(DateTime fromDate, DateTime toDate, string productId);
}