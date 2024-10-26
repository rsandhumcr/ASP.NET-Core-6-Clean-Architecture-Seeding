namespace CompanyNameSpace.ProjectName.Domain.ImportData.SalesData;

public class ProductFileData
{
    public Guid ProductId { get; set; }
    public string Code { get; set; }
    public string? BarCode { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DepartmentFileData Department { get; set; }
    public List<SaleFileData> Sales { get; set; }
}