using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;

namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Commands.CreateEntityOne
{
    public class CreateEntityOneCommandHandler : IRequestHandler<CreateEntityOneCommand, int>
    {
        private readonly IAsyncRepository<Domain.Entities.EntityOne> _entityOneRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateEntityOneCommandHandler> _logger;
        public CreateEntityOneCommandHandler(IAsyncRepository<Domain.Entities.EntityOne> entityOneRepository,
            IMapper mapper, ILogger<CreateEntityOneCommandHandler> logger)
        {
            _entityOneRepository = entityOneRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> Handle(CreateEntityOneCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEntityOneCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @entityOne = _mapper.Map<Domain.Entities.EntityOne>(request);


            @entityOne = await _entityOneRepository.AddAsync(@entityOne);

            return @entityOne.EntityOneId;
        }
    }
}
