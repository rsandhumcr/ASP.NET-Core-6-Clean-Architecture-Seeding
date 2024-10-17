using CompanyNameSpace.ProjectName.Application.UnitTests.Shared;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneDetail;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneList;
using Shouldly;

namespace CompanyNameSpace.ProjectName.Application.UnitTests.EntityOne.Queries
{
    public  class GetEntityOnePagedListTests : CommandQueryEntityOneTestBase
    {
        [Fact]
        public async Task Handle_Returns_AllEntities()
        {
            //Arrange
            var sut = CreateSut();
            var command = new GetEntityOnePagedListQuery {Page = 1, Size = 5};
            //Act
            var entityOnePaged = await sut.Handle(command, CancellationToken.None);
            //Assert
            entityOnePaged.EntityOnes.Count.ShouldBe(3);
            entityOnePaged.Page.ShouldBe(1);
            entityOnePaged.Size.ShouldBe(5);
        }

        [Fact] 
        public async Task Handle_Returns_ExpectedDetails()
        {
            //Arrange
            var sut = CreateSut();
            var command = new GetEntityOnePagedListQuery { Page = 1, Size = 5 };
            //Act
            var entityOnePaged = await sut.Handle(command, CancellationToken.None);
            //Assert
            CheckPagedEntityOneListVm(entityOnePaged, 0, "Entity One", "The first entity.", 1.21M, 1);
            CheckPagedEntityOneListVm(entityOnePaged, 1, "Entity Two", "The second entity.", 1.22M, 2);
            CheckPagedEntityOneListVm(entityOnePaged, 2, "Entity Three", "The third entity.", 1.23M, 3);
        }

        [Fact]
        public async Task Handle_PageOne_ReturnsExpectedData()
        {
            //Arrange
            var sut = CreateSut();
            var command = new GetEntityOnePagedListQuery { Page = 1, Size = 1 };
            //Act
            var entityOnePaged = await sut.Handle(command, CancellationToken.None);
            //Assert
            entityOnePaged.EntityOnes.Count.ShouldBe(1);
            entityOnePaged.Page.ShouldBe(1);
            entityOnePaged.Size.ShouldBe(1);
            CheckPagedEntityOneListVm(entityOnePaged, 0, "Entity One", "The first entity.", 1.21M, 1);
        }

        [Fact]
        public async Task Handle_PageTwo_ReturnsExpectedData()
        {
            //Arrange
            var sut = CreateSut();
            var command = new GetEntityOnePagedListQuery { Page = 2, Size = 1 };
            //Act
            var entityOnePaged = await sut.Handle(command, CancellationToken.None);
            //Assert
            entityOnePaged.EntityOnes.Count.ShouldBe(1);
            entityOnePaged.Page.ShouldBe(2);
            entityOnePaged.Size.ShouldBe(1);
            CheckPagedEntityOneListVm(entityOnePaged, 0, "Entity Two", "The second entity.", 1.22M, 2);
        }


        private void CheckPagedEntityOneListVm(EntityOneListVm entities, int index, string name, string description, 
            decimal price, int typeId)
        {
            var entity = entities.EntityOnes.ToList()[index];
            entity.Name.ShouldBe(name);
            entity.Description.ShouldBe(description);
            entity.Price.ShouldBe(price);
            entity.TypeId.ShouldBe(typeId);
        }

        private GetEntityOnePagedListQueryHandler CreateSut()
        {
            return new GetEntityOnePagedListQueryHandler(MockEntityOneRepository.Object, Mapper);
        }
    }
}
