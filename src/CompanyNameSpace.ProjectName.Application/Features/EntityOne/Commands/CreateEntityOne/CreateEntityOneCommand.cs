using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Commands.CreateEntityOne;

public class CreateEntityOneCommand : IRequest<int>
{
    public int TypeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Description { get; set; }

    public override string ToString()
    {
        return $"EntityOne name: {Name}; Price: {Price}; Description: {Description}";
    }
}