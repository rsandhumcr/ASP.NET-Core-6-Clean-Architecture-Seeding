using MediatR;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneDetail;


namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneList
{
    public class GetEntityOnePagedListQuery: IRequest<EntityOneListVm>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
