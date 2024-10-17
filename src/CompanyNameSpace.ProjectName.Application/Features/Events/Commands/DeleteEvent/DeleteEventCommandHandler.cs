using AutoMapper;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using CompanyNameSpace.ProjectName.Application.Exceptions;
using CompanyNameSpace.ProjectName.Domain.Entities;
using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.Events.Commands.DeleteEvent;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
{
    private readonly IAsyncRepository<Event> _eventRepository;
    private readonly IMapper _mapper;

    public DeleteEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }

    public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);

        if (eventToDelete == null) throw new NotFoundException(nameof(Event), request.EventId);

        await _eventRepository.DeleteAsync(eventToDelete);

        return Unit.Value;
    }
}