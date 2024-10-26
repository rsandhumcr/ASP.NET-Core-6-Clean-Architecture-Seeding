using CompanyNameSpace.ProjectName.Application.Responses;

namespace CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Commands.ImportSalesData;

public class ImportSalesDataCommandResponse : BaseResponse
{
    public int FilesUploaded { get; set; }
    public int DepartmentsAdded { get; set; }
    public int DepartmentsUploaded { get; set; }
    public int ProductsAdded { get; set; }
    public int ProductsUploaded { get; set; }
    public int SalesAdded { get; set; }
    public int SalesUploaded { get; set; }
}