using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand: IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
