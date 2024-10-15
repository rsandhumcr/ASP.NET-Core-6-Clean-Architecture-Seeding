using MediatR;

namespace CompanyNameSpace.ProjectName.Application.Features.EntityOne.Commands.DeleteEntityOne
{
    public class DeleteEntityOneCommand: IRequest
    {
        public int EntityOneId { get; set; }
    }
}
