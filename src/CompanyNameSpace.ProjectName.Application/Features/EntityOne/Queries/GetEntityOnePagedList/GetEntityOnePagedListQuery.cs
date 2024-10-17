using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOnePagedList;

public class GetEntityOnePagedListQuery : IRequest<EntityOneListVm>
{
    public int Page { get; set; }
    public int Size { get; set; }
}