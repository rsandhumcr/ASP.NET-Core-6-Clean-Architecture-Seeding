using AutoMapper;
using MediatR;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneDetail;
using CompanyNameSpace.ProjectName.Application.Features.Events.Queries.GetEventsList;


namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneList
{
    public class GetEntityOneListQueryHandler: IRequestHandler<GetEntityOneListQuery, List<EntityOneListVm>>
    {
        private readonly IAsyncRepository<Domain.Entities.EntityOne> _entityOneRepository;
        private readonly IMapper _mapper;

        public GetEntityOneListQueryHandler(IAsyncRepository<Domain.Entities.EntityOne> entityOneRepository,
            IMapper mapper)
        {
            _entityOneRepository = entityOneRepository;
            _mapper = mapper;
        }
        public async Task<List<EntityOneListVm>> Handle(GetEntityOneListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = await _entityOneRepository.ListAllAsync();
            return _mapper.Map<List<EntityOneListVm>>(allEvents);
        }
    }
}
