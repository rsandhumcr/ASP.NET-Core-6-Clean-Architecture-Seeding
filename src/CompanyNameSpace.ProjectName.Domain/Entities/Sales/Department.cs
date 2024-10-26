using CompanyNameSpace.ProjectName.Domain.Common;

namespace CompanyNameSpace.ProjectName.Domain.Entities.Sales;

public class Department : AuditableEntity
{
    public int DepartmentId { get; set; }
    public string DepartmentCode { get; set; }
    public string Name { get; set; }
}