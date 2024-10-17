using CompanyNameSpace.ProjectName.Application.Exceptions;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Commands.CreateEntityOne;
using CompanyNameSpace.ProjectName.Application.UnitTests.Shared;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace CompanyNameSpace.ProjectName.Application.UnitTests.EntityOne.Commands;

public class CreateEntityOneTests : CommandQueryEntityOneTestBase
{
    private readonly Mock<ILogger<CreateEntityOneCommandHandler>> _logger = new();

    [Fact]
    public async Task Handle_ValidEntity_AddedToEntityOne()
    {
        //Arrange
        var command = CreateEntityOneCommand();
        var sut = CreateSut();
        //Act
        await sut.Handle(command, CancellationToken.None);
        //Assert
        var allEntityOnes = await MockEntityOneRepository.Object.ListAllAsync();
        allEntityOnes.Count.ShouldBe(4);
    }

    [Fact]
    public async Task Handle_ValidEntity_AddedToEntityOneDetailsAreAsExpected()
    {
        //Arrange
        var command = CreateEntityOneCommand();
        var sut = CreateSut();
        //Act
        var newId = await sut.Handle(command, CancellationToken.None);
        //Assert
        var allEntityOnes = await MockEntityOneRepository.Object.ListAllAsync();
        var newEntity = allEntityOnes.First(ent => ent.EntityOneId == newId);

        newEntity.ShouldNotBeNull();
        newEntity.EntityOneId.ShouldBe(newId);
        newEntity.Name.ShouldBe(command.Name);
        newEntity.Description.ShouldBe(command.Description);
        newEntity.Price.ShouldBe(command.Price);
        newEntity.TypeId.ShouldBe(command.TypeId);
    }

    [Fact]
    public async Task Handle_InvalidEntityNoName_ValidationException()
    {
        //Arrange
        var command = CreateEntityOneCommand();
        command.Name = string.Empty;
        var sut = CreateSut();
        //Act
        var response = await Assert.ThrowsAsync<ValidationException>(() => sut.Handle(command, CancellationToken.None));
        //Assert
        CheckValidationExceptionCount(response, 1);
        CheckValidationException(response, 0, "Name is required.");
    }

    [Fact]
    public async Task Handle_InvalidEntityNoPrice_ValidationException()
    {
        //Arrange
        var command = CreateEntityOneCommand();
        command.Price = 0;
        var sut = CreateSut();
        //Act
        var response = await Assert.ThrowsAsync<ValidationException>(() => sut.Handle(command, CancellationToken.None));
        //Assert
        CheckValidationExceptionCount(response, 2);
        CheckValidationException(response, 0, "Price is required.");
        CheckValidationException(response, 1, "'Price' must be greater than '0'.");
    }


    private CreateEntityOneCommand CreateEntityOneCommand()
    {
        var command = new CreateEntityOneCommand
        {
            Name = "TestName",
            Description = "DescriptionName",
            Price = 1.23M,
            TypeId = 1
        };
        return command;
    }

    private CreateEntityOneCommandHandler CreateSut()
    {
        return new CreateEntityOneCommandHandler(MockEntityOneRepository.Object, Mapper, _logger.Object);
    }
}