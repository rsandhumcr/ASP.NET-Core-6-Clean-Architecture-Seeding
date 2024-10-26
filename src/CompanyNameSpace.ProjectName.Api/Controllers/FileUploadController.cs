using CompanyNameSpace.ProjectName.Api.Services;
using CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Commands.ImportSalesData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompanyNameSpace.ProjectName.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileUploadController : ControllerBase
{
    private readonly IFormFileConvertor _formFileConvertor;
    private readonly IMediator _mediator;

    public FileUploadController(IFormFileConvertor formFileConvertor,
        IMediator mediator)
    {
        _formFileConvertor = formFileConvertor;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] List<IFormFile> files)
    {
        var size = files.Sum(f => f.Length);

        var fileImportData = await _formFileConvertor.ConvertToFileData(files);

        var dtos = await _mediator.Send(new ImportSalesDataCommand { FileImports = fileImportData });
        return Ok(dtos);
    }
}