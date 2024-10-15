using AutoMapper;
using CompanyNameSpace.ProjectName.Application.Features.Categories.Commands.CreateCategory;
using CompanyNameSpace.ProjectName.Application.Features.Categories.Queries.GetCategoriesList;
using CompanyNameSpace.ProjectName.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Commands.CreateEntityOne;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Commands.UpdateEntityOne;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneDetail;
using CompanyNameSpace.ProjectName.Application.Features.Events.Commands.CreateEvent;
using CompanyNameSpace.ProjectName.Application.Features.Events.Commands.UpdateEvent;
using CompanyNameSpace.ProjectName.Application.Features.Events.Queries.GetEventDetail;
using CompanyNameSpace.ProjectName.Application.Features.Events.Queries.GetEventsExport;
using CompanyNameSpace.ProjectName.Application.Features.Events.Queries.GetEventsList;
using CompanyNameSpace.ProjectName.Application.Features.Orders.GetOrdersForMonth;
using CompanyNameSpace.ProjectName.Domain.Entities;

namespace CompanyNameSpace.ProjectName.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<EntityOne, EntityOneDetailVm>().ReverseMap();
            CreateMap<EntityOne, EntityOneListVm>().ReverseMap();
            CreateMap<EntityOne, CreateEntityOneCommand>().ReverseMap();
            CreateMap<EntityOne, UpdateEntityOneCommand>().ReverseMap();

        }
    }
}
