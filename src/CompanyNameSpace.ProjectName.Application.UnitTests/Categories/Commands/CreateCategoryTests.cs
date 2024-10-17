using AutoMapper;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using CompanyNameSpace.ProjectName.Application.Features.Categories.Commands.CreateCategory;
using CompanyNameSpace.ProjectName.Application.Profiles;
using CompanyNameSpace.ProjectName.Application.UnitTests.Mocks;
using CompanyNameSpace.ProjectName.Domain.Entities;
using Moq;
using Shouldly;

namespace CompanyNameSpace.ProjectName.Application.UnitTests.Categories.Commands;

public class CreateCategoryTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

    public CreateCategoryTests()
    {
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
        var configurationProvider = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidCategory_AddedToCategoriesRepo()
    {
        //Arrange
        var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);
        //Act
        await handler.Handle(new CreateCategoryCommand { Name = "Test" }, CancellationToken.None);
        //Assert
        var allCategories = await _mockCategoryRepository.Object.ListAllAsync();
        allCategories.Count.ShouldBe(5);
    }
}