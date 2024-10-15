using AutoMapper;
using MediatR;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using CompanyNameSpace.ProjectName.Application.Exceptions;
using CompanyNameSpace.ProjectName.Application.Features.Events.Commands.UpdateEvent;
using CompanyNameSpace.ProjectName.Domain.Entities;

namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Commands.UpdateEntityOne
{
    public class UpdateEntityOneCommandHandler: IRequestHandler<UpdateEntityOneCommand>
    {
        public IAsyncRepository<Domain.Entities.EntityOne> _entityOneRepository { get; }
        private readonly IMapper _mapper;

        public UpdateEntityOneCommandHandler(IMapper mapper, IAsyncRepository<Domain.Entities.EntityOne> entityOneRepository)
        {
            _entityOneRepository = entityOneRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEntityOneCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _entityOneRepository.GetByIntIdAsync(request.EntityOneId);
            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(Event), request.EntityOneId);
            }

            var validator = new UpdateEntityOneCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

            await _entityOneRepository.UpdateAsync(eventToUpdate);

            return Unit.Value;
        }
    }
}
