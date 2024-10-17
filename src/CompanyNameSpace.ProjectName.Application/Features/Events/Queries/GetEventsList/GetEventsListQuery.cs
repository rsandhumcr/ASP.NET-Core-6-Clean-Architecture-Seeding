using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.Events.Queries.GetEventsList;

public class GetEventsListQuery : IRequest<List<EventListVm>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}