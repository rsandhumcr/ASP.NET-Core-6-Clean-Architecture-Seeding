using AutoMapper;
using Shouldly;
using CompanyNameSpace.ProjectName.Application.Exceptions;
using CompanyNameSpace.ProjectName.Application.Profiles;

namespace CompanyNameSpace.ProjectName.Application.UnitTests.Shared;

public class CommandQueryTestBase
{
    protected readonly IMapper Mapper;

    public CommandQueryTestBase()
    {
        var configurationProvider = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });

        Mapper = configurationProvider.CreateMapper();
    }

    protected void CheckValidationExceptionCount(ValidationException response, int expectedCount)
    {
        response.ValidationErrors.Count.ShouldBe(expectedCount);
    }

    protected void CheckValidationException(ValidationException response, int index, string expectedMessage)
    {
        response.ValidationErrors[index].ShouldBe(expectedMessage);
    }

    protected void CheckNotFoundException(NotFoundException response, string expectedMessage)
    {
        response.Message.ShouldBe(expectedMessage);
    }
}