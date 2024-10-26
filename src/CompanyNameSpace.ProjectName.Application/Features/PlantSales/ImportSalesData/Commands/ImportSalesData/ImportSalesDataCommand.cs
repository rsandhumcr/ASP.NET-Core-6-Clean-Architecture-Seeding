using CompanyNameSpace.ProjectName.Application.Models.FileUpload;
using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Commands.ImportSalesData;

public class ImportSalesDataCommand : IRequest<ImportSalesDataCommandResponse>
{
    public IReadOnlyCollection<FileDataDto> FileImports { get; set; }
}