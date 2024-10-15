using CompanyNameSpace.ProjectName.Application.UnitTests.Shared;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneDetail;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneList;
using Shouldly;

namespace CompanyNameSpace.ProjectName.Application.UnitTests.EntityOne.Queries
{
    public  class GetEntityOneListTests : CommandQueryEntityOneTestBase
    {
        [Fact]
        public async Task Handle_Returns_AllEntities()
        {
            //Arrange
            var sut = CreateSut();
            //Act
            var entities = await sut.Handle(new GetEntityOneListQuery(), CancellationToken.None);
            //Assert
            entities.Count.ShouldBe(3);
        }

        [Fact] public async Task Handle_Returns_ExpectedDetails()
        {
            //Arrange
            var sut = CreateSut();
            //Act
            var entities = await sut.Handle(new GetEntityOneListQuery(), CancellationToken.None);
            //Assert
            CheckEntityOneVm(entities, 0, "Entity One", "The first entity.", 1.21M, 1);
            CheckEntityOneVm(entities, 1, "Entity Two", "The second entity.", 1.22M, 2);
            CheckEntityOneVm(entities, 2, "Entity Three", "The third entity.", 1.23M, 3);
        }


        private void CheckEntityOneVm(List<EntityOneListVm> entities, int index, string name, string description, 
            decimal price, int typeId)
        {
            var entity = entities[index];
            entity.Name.ShouldBe(name);
            entity.Description.ShouldBe(description);
            entity.Price.ShouldBe(price);
            entity.TypeId.ShouldBe(typeId);
        }

        private GetEntityOneListQueryHandler CreateSut()
        {
            return new GetEntityOneListQueryHandler(MockEntityOneRepository.Object, Mapper);
        }
    }
}
