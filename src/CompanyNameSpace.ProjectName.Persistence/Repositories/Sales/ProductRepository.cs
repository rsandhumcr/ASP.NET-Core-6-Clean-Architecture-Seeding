using CompanyNameSpace.ProjectName.Application.Contracts.Persistence.Sales;
using CompanyNameSpace.ProjectName.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;

namespace CompanyNameSpace.ProjectName.Persistence.Repositories.Sales;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ProjectNameDbContext dbContext) : base(dbContext)
    {
    }


    public async Task<IReadOnlyList<Product>> GetByCodes(List<string> codes)
    {
        var matches = await DbContext.Products
            .Where(e => codes.Contains(e.Code))
            .ToListAsync();
        return matches;
    }
}