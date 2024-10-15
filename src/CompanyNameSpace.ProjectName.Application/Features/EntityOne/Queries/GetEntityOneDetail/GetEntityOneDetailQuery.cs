using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneDetail
{
    public class GetEntityOneDetailQuery: IRequest<EntityOneDetailVm>
    {
        public int Id { get; set; }
    }
}
