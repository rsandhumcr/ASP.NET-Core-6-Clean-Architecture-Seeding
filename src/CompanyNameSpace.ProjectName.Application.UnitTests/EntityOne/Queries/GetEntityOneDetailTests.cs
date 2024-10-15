using Shouldly;
using CompanyNameSpace.ProjectName.Application.UnitTests.Shared;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneDetail;
using CompanyNameSpace.ProjectName.Application.Exceptions;

namespace CompanyNameSpace.ProjectName.Application.UnitTests.EntityOne.Queries
{
    public class GetEntityOneDetailTests : CommandQueryEntityOneTestBase
    {
        [Fact]
        public async Task Handle_ValidId_ReturnsExceptedDetails()
        {
            //Arrange
            var command = new GetEntityOneDetailQuery{Id=2};
            var sut = CreateSut();
            //Act
            var entityOne = await sut.Handle(command, CancellationToken.None);
            //Assert
            entityOne.Name.ShouldBe("Entity Two");
            entityOne.Description.ShouldBe("The second entity.");
            entityOne.Price.ShouldBe(1.22M);
            entityOne.TypeId.ShouldBe(2);
        }

        [Fact]
        public async Task Handle_InvalidId_ExceptionNotFound()
        {
            //Arrange
            var command = new GetEntityOneDetailQuery { Id = 5 };
            var sut = CreateSut();
            //Act
            var response = await Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(command, CancellationToken.None));
            //Assert
            CheckNotFoundException(response, "entityOne (5) is not found");
        }

        private GetEntityOneDetailQueryHandler CreateSut()
        {
            return new GetEntityOneDetailQueryHandler(MockEntityOneRepository.Object, Mapper);
        }
    }
}
