using CompanyNameSpace.ProjectName.Application.Features.Events.Queries.GetEventsExport;

namespace CompanyNameSpace.ProjectName.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
