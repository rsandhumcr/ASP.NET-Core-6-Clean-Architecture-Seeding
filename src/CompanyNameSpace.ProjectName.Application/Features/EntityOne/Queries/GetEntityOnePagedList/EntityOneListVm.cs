namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOnePagedList;

public class EntityOneListVm
{
    public int Page { get; set; }
    public int Size { get; set; }
    public ICollection<EntityOneDto>? EntityOnes { get; set; }
}