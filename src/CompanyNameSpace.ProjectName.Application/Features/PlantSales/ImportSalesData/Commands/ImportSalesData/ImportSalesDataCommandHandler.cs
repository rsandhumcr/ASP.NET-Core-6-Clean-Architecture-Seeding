using AutoMapper;
using CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Services.ImportSalesData;
using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Commands.ImportSalesData;

public class ImportSalesDataCommandHandler : IRequestHandler<ImportSalesDataCommand, ImportSalesDataCommandResponse>
{
    private readonly IDataProcessor _dataProcessor;
    private readonly IMapper _mapper;


    public ImportSalesDataCommandHandler(
        IMapper mapper,
        IDataProcessor dataProcessor)
    {
        _mapper = mapper;
        _dataProcessor = dataProcessor;
    }

    public async Task<ImportSalesDataCommandResponse> Handle(ImportSalesDataCommand request,
        CancellationToken cancellationToken)
    {
        var dataObjects = _dataProcessor.ProcessJsonData(request);

        var result = await ProcessData(dataObjects);

        return result;
    }


    private async Task<ImportSalesDataCommandResponse> ProcessData(
        List<Domain.ImportData.SalesData.ImportSalesData> importedSalesData)
    {
        var departmentResults = await _dataProcessor.ProcessDepartmentData(importedSalesData);
        var productResults = await _dataProcessor.ProcessProductData(departmentResults.Departments, importedSalesData);
        var addSalesNo = await _dataProcessor.ProcessSaleData(importedSalesData);
        return new ImportSalesDataCommandResponse
        {
            DepartmentsAdded = departmentResults.DepartmentAdded,
            ProductsAdded = productResults.ProductAdded,
            SalesAdded = addSalesNo
        };
    }
}