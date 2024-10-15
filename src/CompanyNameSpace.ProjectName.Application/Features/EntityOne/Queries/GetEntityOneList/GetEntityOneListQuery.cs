using MediatR;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneDetail;


namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneList
{
    public class GetEntityOneListQuery: IRequest<List<EntityOneListVm>>
    {
    }
}
