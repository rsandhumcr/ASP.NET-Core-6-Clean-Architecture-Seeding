﻿using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
{
}