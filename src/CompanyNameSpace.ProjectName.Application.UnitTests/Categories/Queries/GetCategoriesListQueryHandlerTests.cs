using AutoMapper;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using CompanyNameSpace.ProjectName.Application.Features.Categories.Queries.GetCategoriesList;
using CompanyNameSpace.ProjectName.Application.Profiles;
using CompanyNameSpace.ProjectName.Application.UnitTests.Mocks;
using CompanyNameSpace.ProjectName.Domain.Entities;
using Moq;
using Shouldly;

namespace CompanyNameSpace.ProjectName.Application.UnitTests.Categories.Queries;

public class GetCategoriesListQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

    public GetCategoriesListQueryHandlerTests()
    {
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
        var configurationProvider = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task GetCategoriesListTest()
    {
        //Arrange
        var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRepository.Object);
        //Act
        var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);
        //Assert
        result.ShouldBeOfType<List<CategoryListVm>>();
        result.Count.ShouldBe(4);
    }
}