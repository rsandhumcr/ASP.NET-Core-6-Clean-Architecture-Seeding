using CompanyNameSpace.ProjectName.Domain.Common;

namespace CompanyNameSpace.ProjectName.Domain.Entities.Sales;

public class Sale : AuditableEntity
{
    public int SaleId { get; set; }
    public DateTime From { get; set; }
    public DateTime Until { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}