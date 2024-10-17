using Moq;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using CompanyNameSpace.ProjectName.Application.UnitTests.Mocks;

namespace CompanyNameSpace.ProjectName.Application.UnitTests.Shared
{
    public class CommandQueryEntityOneTestBase: CommandQueryTestBase
    {
        protected readonly Mock<IEntityOneRepository> MockEntityOneRepository 
            = RepositoryMocks.GetEntityOneRepository();


    }
}
