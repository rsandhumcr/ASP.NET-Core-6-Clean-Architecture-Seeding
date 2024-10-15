using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery: IRequest<List<EventListVm>>
    {
    }
}
