using CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Services.ImportSalesData;
using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Commands.ImportSalesData;

public class ImportSalesDataCommandHandler : IRequestHandler<ImportSalesDataCommand, ImportSalesDataCommandResponse>
{
    private readonly IDataProcessor _dataProcessor;

    public ImportSalesDataCommandHandler(
        IDataProcessor dataProcessor)
    {
        _dataProcessor = dataProcessor;
    }

    public async Task<ImportSalesDataCommandResponse> Handle(ImportSalesDataCommand request,
        CancellationToken cancellationToken)
    {
        if (request.FileImports.Count == 0)
            return new
                ImportSalesDataCommandResponse { Success = false, Message = "File contains no data." };

        var dataObjects = _dataProcessor.ProcessJsonData(request);

        var result = await ProcessData(dataObjects);

        return result;
    }

    private async Task<ImportSalesDataCommandResponse> ProcessData(
        List<Domain.ImportData.SalesData.ImportSalesData> importedSalesData)
    {
        var departmentResults = await _dataProcessor.ProcessDepartmentData(importedSalesData);
        var productResults = await _dataProcessor.ProcessProductData(departmentResults.Departments, importedSalesData);
        var saleDataResult = await _dataProcessor.ProcessSaleData(importedSalesData);
        return new ImportSalesDataCommandResponse
        {
            DepartmentsAdded = departmentResults.DepartmentsAdded,
            DepartmentsUploaded = departmentResults.DepartmentsUploaded,
            ProductsAdded = productResults.ProductsAdded,
            ProductsUploaded = productResults.ProductsUploaded,
            SalesAdded = saleDataResult.SalesAdded,
            SalesUploaded = saleDataResult.SalesUploaded,
            FilesUploaded = importedSalesData.Count,
            Success = importedSalesData.Count > 0,
            Message = $"Uploaded {importedSalesData.Count} file/s, with {saleDataResult.SalesAdded} sale/s added."
        };
    }
}