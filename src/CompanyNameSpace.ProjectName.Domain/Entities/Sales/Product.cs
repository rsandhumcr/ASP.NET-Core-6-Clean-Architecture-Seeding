using CompanyNameSpace.ProjectName.Domain.Common;

namespace CompanyNameSpace.ProjectName.Domain.Entities.Sales;

public class Product : AuditableEntity
{
    public string ProductId { get; set; }
    public string Code { get; set; }
    public string? BarCode { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public List<Sale>? Sales { get; set; }
}