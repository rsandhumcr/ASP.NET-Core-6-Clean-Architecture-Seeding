using Shouldly;
using CompanyNameSpace.ProjectName.Application.Exceptions;
using CompanyNameSpace.ProjectName.Application.UnitTests.Shared;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Commands.DeleteEntityOne;

namespace CompanyNameSpace.ProjectName.Application.UnitTests.EntityOne.Commands
{
    public  class DeleteEntityOneTests : CommandQueryEntityOneTestBase
    {
        [Fact]
        public async Task Handle_ValidId_DeleteEntityOneInRepo()
        {
            //Arrange
            var command = new DeleteEntityOneCommand { EntityOneId = 2 };
            var sut = CreateSut();
            //Act
            await sut.Handle(command, CancellationToken.None);
            //Assert
            var allEntityOnes = await MockEntityOneRepository.Object.ListAllAsync();
            allEntityOnes.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Handle_InvalidId_ExceptionNotFound()
        {
            //Arrange
            var command = new DeleteEntityOneCommand { EntityOneId = 4 };
            var sut = CreateSut();
            //Act
            var response = await Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(command, CancellationToken.None));
            //Assert
            CheckNotFoundException(response, "Event (4) is not found");
        }

        private DeleteEntityOneCommandHandler CreateSut()
        {
            return new DeleteEntityOneCommandHandler(Mapper, MockEntityOneRepository.Object);
        }

    }
}
