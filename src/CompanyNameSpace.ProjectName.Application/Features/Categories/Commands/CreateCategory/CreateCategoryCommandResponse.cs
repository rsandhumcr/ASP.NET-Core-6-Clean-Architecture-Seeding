using CompanyNameSpace.ProjectName.Application.Responses;

namespace CompanyNameSpace.ProjectName.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandResponse : BaseResponse
{
    public CreateCategoryDto Category { get; set; } = default!;
}