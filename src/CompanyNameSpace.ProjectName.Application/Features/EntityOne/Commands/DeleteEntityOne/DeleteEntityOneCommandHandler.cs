using AutoMapper;
using MediatR;
using CompanyNameSpace.ProjectName.Domain.Entities;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using CompanyNameSpace.ProjectName.Application.Exceptions;

namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Commands.DeleteEntityOne
{
    public class DeleteEntityOneCommandHandler: IRequestHandler<DeleteEntityOneCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.EntityOne> _entityOneRepository;

        public DeleteEntityOneCommandHandler(IMapper mapper, IAsyncRepository<Domain.Entities.EntityOne> entityOneRepository)
        {
            _mapper = mapper;
            _entityOneRepository = entityOneRepository;
        }
        public async Task<Unit> Handle(DeleteEntityOneCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _entityOneRepository.GetByIntIdAsync(request.EntityOneId);

            if (eventToDelete == null)
            {
                throw new NotFoundException(nameof(Event), request.EntityOneId);
            }

            await _entityOneRepository.DeleteAsync(eventToDelete);

            return Unit.Value;
        }
    }
}
