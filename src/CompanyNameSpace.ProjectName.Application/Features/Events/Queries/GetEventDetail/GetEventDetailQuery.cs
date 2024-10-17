using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.Events.Queries.GetEventDetail;

public class GetEventDetailQuery : IRequest<EventDetailVm>
{
    public Guid Id { get; set; }
}