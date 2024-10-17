using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using CompanyNameSpace.ProjectName.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyNameSpace.ProjectName.Persistence.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(ProjectNameDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size)
    {
        return await DbContext.Orders.Where(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year)
            .Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
    }

    public async Task<int> GetTotalCountOfOrdersForMonth(DateTime date)
    {
        return await DbContext.Orders.CountAsync(x =>
            x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year);
    }
}