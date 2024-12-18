﻿using AutoMapper;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using CompanyNameSpace.ProjectName.Application.Exceptions;
using CompanyNameSpace.ProjectName.Domain.Entities;
using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.Events.Queries.GetEventDetail;

public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
{
    private readonly IAsyncRepository<Category> _categoryRepository;
    private readonly IAsyncRepository<Event> _eventRepository;
    private readonly IMapper _mapper;

    public GetEventDetailQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository,
        IAsyncRepository<Category> categoryRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.GetByIdAsync(request.Id);
        var eventDetailDto = _mapper.Map<EventDetailVm>(@event);

        var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);

        if (category == null) throw new NotFoundException(nameof(Event), request.Id);
        eventDetailDto.Category = _mapper.Map<CategoryDto>(category);

        return eventDetailDto;
    }
}