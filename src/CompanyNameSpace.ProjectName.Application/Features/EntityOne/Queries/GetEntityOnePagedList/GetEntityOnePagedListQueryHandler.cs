using AutoMapper;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOnePagedList;

public class GetEntityOnePagedListQueryHandler : IRequestHandler<GetEntityOnePagedListQuery, EntityOneListVm>
{
    private readonly IEntityOneRepository _entityOneRepository;
    private readonly IMapper _mapper;

    public GetEntityOnePagedListQueryHandler(IEntityOneRepository entityOneRepository,
        IMapper mapper)
    {
        _entityOneRepository = entityOneRepository;
        _mapper = mapper;
    }

    public async Task<EntityOneListVm> Handle(GetEntityOnePagedListQuery request, CancellationToken cancellationToken)
    {
        var allEvents = await _entityOneRepository.GetPagedEntityOneList(request.Page, request.Size);
        var entities = _mapper.Map<List<EntityOneDto>>(allEvents);
        var results = new EntityOneListVm { Size = request.Size, Page = request.Page, EntityOnes = entities };
        return results;
    }
}