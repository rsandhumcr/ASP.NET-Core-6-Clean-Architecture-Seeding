using Shouldly;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Commands.UpdateEntityOne;
using CompanyNameSpace.ProjectName.Application.UnitTests.Shared;
using CompanyNameSpace.ProjectName.Application.Exceptions;

namespace CompanyNameSpace.ProjectName.Application.UnitTests.EntityOne.Commands
{
    public class UpdateEntityOneTests : CommandQueryEntityOneTestBase
    {
        [Fact]
        public async Task Handle_ValidEntity_DoesNotAddToRepo()
        {
            //Arrange
            var command = CreateEntityOneCommand();
            var sut = CreateSut();
            //Act
            await sut.Handle(command, CancellationToken.None);
            //Assert
            var entityOnes = await MockEntityOneRepository.Object.ListAllAsync();
            entityOnes.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Handle_ValidEntity_UpdatesRepo()
        {
            //Arrange
            var command = CreateEntityOneCommand();
            var sut = CreateSut();
            //Act
            await sut.Handle(command, CancellationToken.None);
            //Assert
            var entityOnes = await MockEntityOneRepository.Object.ListAllAsync();
            var entityOne = entityOnes.First(ent => ent.EntityOneId == command.EntityOneId);

            entityOne.Name.ShouldBe(entityOne.Name);
            entityOne.Description.ShouldBe(entityOne.Description);
            entityOne.Price.ShouldBe(entityOne.Price);
            entityOne.TypeId.ShouldBe(entityOne.TypeId);
        }

        [Fact]
        public async Task Handle_InvalidEntityId_ExceptionNotFound()
        {
            //Arrange
            var command = CreateEntityOneCommand();
            command.EntityOneId = 10;
            var sut = CreateSut();
            //Act
            var response = await Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(command, CancellationToken.None));
            //Assert
            CheckNotFoundException(response, "Event (10) is not found");
        }

        [Fact]
        public async Task Handle_InvalidEntityNoName_ExceptionValidation()
        {
            //Arrange
            var command = CreateEntityOneCommand();
            command.Name = string.Empty;
            var sut = CreateSut();
            //Act
            var response = await Assert.ThrowsAsync<ValidationException>(() => sut.Handle(command, CancellationToken.None));
            //Assert
            response.ValidationErrors.Count.ShouldBe(1);
            CheckValidationException(response, 0, "Name is required.");
        }

        [Fact]
        public async Task Handle_InvalidEntityNoPrice_ExceptionValidation()
        {
            //Arrange
            var command = CreateEntityOneCommand();
            command.Price = 0;
            var sut = CreateSut();
            //Act
            var response = await Assert.ThrowsAsync<ValidationException>(() => sut.Handle(command, CancellationToken.None));
            //Assert
            response.ValidationErrors.Count.ShouldBe(2);
            CheckValidationException(response, 0, "Price is required.");
            CheckValidationException(response, 1, "'Price' must be greater than '0'.");

        }

        private UpdateEntityOneCommand CreateEntityOneCommand()
        {
            var command = new UpdateEntityOneCommand
            {
                EntityOneId = 2,
                Name = "UpdateTestName",
                Description = "UpdateDescriptionName",
                Price = 2.34M,
                TypeId = 12
            };
            return command;
        }

        private UpdateEntityOneCommandHandler CreateSut()
        {
            return new UpdateEntityOneCommandHandler(Mapper,MockEntityOneRepository.Object);
        }
    }
}
