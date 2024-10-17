using AutoMapper;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using CompanyNameSpace.ProjectName.Application.Exceptions;
using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneDetail;

public class GetEntityOneDetailQueryHandler : IRequestHandler<GetEntityOneDetailQuery, EntityOneDetailVm>
{
    private readonly IAsyncRepository<Domain.Entities.EntityOne> _entityOneRepository;
    private readonly IMapper _mapper;

    public GetEntityOneDetailQueryHandler(IAsyncRepository<Domain.Entities.EntityOne> entityOneRepository,
        IMapper mapper)
    {
        _entityOneRepository = entityOneRepository;
        _mapper = mapper;
    }

    public async Task<EntityOneDetailVm> Handle(GetEntityOneDetailQuery request, CancellationToken cancellationToken)
    {
        var entityOne = await _entityOneRepository.GetByIntIdAsync(request.Id);
        if (entityOne == null) throw new NotFoundException(nameof(entityOne), request.Id);
        var entityOneDto = _mapper.Map<EntityOneDetailVm>(entityOne);

        return entityOneDto;
    }
}