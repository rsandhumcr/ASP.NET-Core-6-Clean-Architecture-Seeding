using CompanyNameSpace.ProjectName.Domain.Common;

namespace CompanyNameSpace.ProjectName.Domain.Entities;

public class EntityOne : AuditableEntity
{
    public int EntityOneId { get; set; }
    public int TypeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Description { get; set; }
}