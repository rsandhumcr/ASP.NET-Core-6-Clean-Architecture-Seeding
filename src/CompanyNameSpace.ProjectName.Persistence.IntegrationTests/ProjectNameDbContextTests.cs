using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using CompanyNameSpace.ProjectName.Application.Contracts;
using CompanyNameSpace.ProjectName.Domain.Entities;


namespace CompanyNameSpace.ProjectName.Persistence.IntegrationTests
{
    public class ProjectNameDbContextTests
    {
        private readonly ProjectNameDbContext _projectNameDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public ProjectNameDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ProjectNameDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _projectNameDbContext = new ProjectNameDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new Event() {EventId = Guid.NewGuid(), Name = "Test event" };

            _projectNameDbContext.Events.Add(ev);
            await _projectNameDbContext.SaveChangesAsync();

            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
