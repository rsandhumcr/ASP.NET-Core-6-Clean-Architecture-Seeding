namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneList
{
    public class EntityOneDto
    {
        public int EntityOneId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
