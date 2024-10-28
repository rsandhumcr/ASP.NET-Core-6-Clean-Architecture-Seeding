using CompanyNameSpace.ProjectName.Application.Contracts.Persistence.Sales;
using CompanyNameSpace.ProjectName.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;

namespace CompanyNameSpace.ProjectName.Persistence.Repositories.Sales;

public class SaleRepository : BaseRepository<Sale>, ISaleRepository
{
    public SaleRepository(ProjectNameDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Sale>> GetBySalesDatesAndProductId(DateTime fromDate, DateTime toDate,
        Guid productId)
    {
        var sales = await DbContext.Sales
            .Where(s => s.From == fromDate && s.Until == toDate && s.ProductId == productId)
            .ToListAsync();
        return sales;
    }

    public async Task<IReadOnlyList<Sale>> GetSalesBetweenDatesAndByProductId(DateTime fromDate, DateTime toDate,
        Guid productId)
    {
        var sales = await DbContext.Sales
            .Where(s => s.From >= fromDate && s.Until <= toDate && s.ProductId == productId)
            .ToListAsync();
        return sales;
    }
}