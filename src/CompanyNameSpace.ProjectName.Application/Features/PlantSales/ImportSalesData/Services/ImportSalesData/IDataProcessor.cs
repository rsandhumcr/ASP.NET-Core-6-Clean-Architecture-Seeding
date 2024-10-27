using CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Commands.ImportSalesData;
using CompanyNameSpace.ProjectName.Domain.Entities.Sales;

namespace CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Services.ImportSalesData;

public interface IDataProcessor
{
    List<Domain.ImportData.SalesData.ImportSalesData> ProcessJsonData(ImportSalesDataCommand request);

    List<Department> ExtractDepartmentsAndConvertToDbEntity(
        List<Domain.ImportData.SalesData.ImportSalesData>? importedDataObjectList);

    List<Product> ExtractProductsAndConvertToDbEntity(
        List<Domain.ImportData.SalesData.ImportSalesData>? importedDataObjectList);

    List<Sale> ExtractSalesAndConvertToDbEntity(
        List<Domain.ImportData.SalesData.ImportSalesData>? importedDataObjectList);

    Task<ProcessDepartmentDataResult> ProcessDepartmentData(List<Department> departmentDbList);

    Task<ProcessProductDataResult> ProcessProductData(IReadOnlyCollection<Department>? departments,
        List<Product> productsList);

    Task<ProcessSaleDataResult> ProcessSaleData(IReadOnlyCollection<Sale>? sales);
}