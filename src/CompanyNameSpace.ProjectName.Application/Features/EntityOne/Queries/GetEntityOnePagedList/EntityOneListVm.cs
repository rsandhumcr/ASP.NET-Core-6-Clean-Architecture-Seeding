using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneList;
using CompanyNameSpace.ProjectName.Application.Features.Orders.GetOrdersForMonth;

namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneDetail
{
    public class EntityOneListVm
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<EntityOneDto>? EntityOnes { get; set; }
    }
}
