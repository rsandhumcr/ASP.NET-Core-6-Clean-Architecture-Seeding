﻿using AutoMapper;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.Categories.Queries.GetCategoriesListWithEvents;

public class
    GetCategoriesListWithEventsQueryHandler : IRequestHandler<GetCategoriesListWithEventsQuery,
    List<CategoryEventListVm>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoriesListWithEventsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventsQuery request,
        CancellationToken cancellationToken)
    {
        var list = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
        return _mapper.Map<List<CategoryEventListVm>>(list);
    }
}