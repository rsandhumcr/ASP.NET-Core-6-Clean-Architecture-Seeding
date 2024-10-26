using CompanyNameSpace.ProjectName.Domain.Entities.Sales;

namespace CompanyNameSpace.ProjectName.Application.Contracts.Persistence.Sales;

public interface ISaleRepository : IAsyncRepository<Sale>
{
    Task<IReadOnlyList<Sale>> GetBySalesDatesAndProductId(DateTime fromDate, DateTime toDate, string productId);
    Task<IReadOnlyList<Sale>> GetSalesBetweenDatesAndByProductId(DateTime fromDate, DateTime toDate, string productId);
}