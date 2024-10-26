using CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Services.ImportSalesData;
using CompanyNameSpace.ProjectName.Application.Utils;
using MediatR;


namespace CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Commands.ImportSalesData;

public class ImportSalesDataCommandHandler : IRequestHandler<ImportSalesDataCommand, ImportSalesDataCommandResponse>
{
    private readonly IDataProcessor _dataProcessor;

    public ImportSalesDataCommandHandler(IDataProcessor dataProcessor)
    {
        _dataProcessor = dataProcessor;
    }

    public async Task<ImportSalesDataCommandResponse> Handle(ImportSalesDataCommand request,
        CancellationToken cancellationToken)
    {
        var validateImportSalesDataResult = ValidateDeserializeImportSalesData(request);
        if (validateImportSalesDataResult.InvalidResponse != null)
            return validateImportSalesDataResult.InvalidResponse;

        var result = await ProcessData(validateImportSalesDataResult.DataObjects);
        return result;
    }

    private ValidateImportSalesDataResult ValidateDeserializeImportSalesData(ImportSalesDataCommand request)
    {
        if (request.FileImports.Count == 0)
            return CreateValidateImportErrorResponse("File contains no data.", "No data.");

        try
        {
            var dataObjects = _dataProcessor.ProcessJsonData(request);
            if (dataObjects.Count == 0)
                return CreateValidateImportErrorResponse("File when processed contains no data.", "No data to process.");

            return new ValidateImportSalesDataResult{DataObjects = dataObjects};
        }
        catch (Exception ex)
        {
            return CreateValidateImportErrorResponse("Issues decoding File data.\n" + GeneralUtils.FormatException(ex), "Invalid file data.");
        }
    }

    private async Task<ImportSalesDataCommandResponse> ProcessData(
        List<Domain.ImportData.SalesData.ImportSalesData>? importedSalesData)
    {
        var departmentResults = await _dataProcessor.ProcessDepartmentData(importedSalesData);
        var productResults = await _dataProcessor.ProcessProductData(departmentResults.Departments, importedSalesData);
        var saleDataResult = await _dataProcessor.ProcessSaleData(importedSalesData);
        var filesSuffix = (importedSalesData != null && importedSalesData.Count > 1) ? "s" : string.Empty;
        var saleDataSuffix = (saleDataResult.SalesAdded > 1) ? "s" : string.Empty;
        var importedSalesDataCount = (importedSalesData?.Count ?? 0);
        return new ImportSalesDataCommandResponse
        {
            DepartmentsAdded = departmentResults.DepartmentsAdded,
            DepartmentsUploaded = departmentResults.DepartmentsUploaded,
            ProductsAdded = productResults.ProductsAdded,
            ProductsUploaded = productResults.ProductsUploaded,
            SalesAdded = saleDataResult.SalesAdded,
            SalesUploaded = saleDataResult.SalesUploaded,
            FilesUploaded = importedSalesDataCount,
            Success = importedSalesDataCount > 0,
            Message = $"Uploaded {importedSalesDataCount} file{filesSuffix}, with {saleDataResult.SalesAdded} sale record{saleDataSuffix} added."
        };
    }

    private ValidateImportSalesDataResult CreateValidateImportErrorResponse(string message, string validationError)
    {
        return new ValidateImportSalesDataResult
        {
            InvalidResponse = new ImportSalesDataCommandResponse
            {
                Success = false,
                Message = message,
                ValidationErrors = new List<string> { validationError }
            }
        };
    }
}

public class ValidateImportSalesDataResult
{
    public ImportSalesDataCommandResponse? InvalidResponse { get; set; }

    public List<Domain.ImportData.SalesData.ImportSalesData>? DataObjects { get; set; }
}