using CompanyNameSpace.ProjectName.Application.Responses;

namespace CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Commands.ImportSalesData;

public class ImportSalesDataCommandResponse : BaseResponse
{
    public int DepartmentsAdded { get; set; }
    public int ProductsAdded { get; set; }
    public int SalesAdded { get; set; }
}