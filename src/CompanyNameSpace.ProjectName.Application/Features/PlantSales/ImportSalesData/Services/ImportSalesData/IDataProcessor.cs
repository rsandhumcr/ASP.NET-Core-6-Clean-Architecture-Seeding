using CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Commands.ImportSalesData;
using CompanyNameSpace.ProjectName.Domain.Entities.Sales;

namespace CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Services.ImportSalesData;

public interface IDataProcessor
{
    List<Domain.ImportData.SalesData.ImportSalesData> ProcessJsonData(ImportSalesDataCommand request);

    Task<ProcessDepartmentDataResult> ProcessDepartmentData(
        List<Domain.ImportData.SalesData.ImportSalesData> importedDataObjectList);

    Task<ProcessProductDataResult> ProcessProductData(IReadOnlyCollection<Department> departments,
        List<Domain.ImportData.SalesData.ImportSalesData> importedDataObjectList);

    Task<int> ProcessSaleData(List<Domain.ImportData.SalesData.ImportSalesData> importedDataObjectList);
}