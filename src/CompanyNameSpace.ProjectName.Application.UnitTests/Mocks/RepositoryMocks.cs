using Moq;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence;
using CompanyNameSpace.ProjectName.Domain.Entities;

namespace CompanyNameSpace.ProjectName.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Category>> GetCategoryRepository()
        {
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var categories = new List<Category>
            {
                new()
                {
                    CategoryId = concertGuid,
                    Name = "Concerts"
                },
                new()
                {
                    CategoryId = musicalGuid,
                    Name = "Musicals"
                },
                new()
                {
                    CategoryId = conferenceGuid,
                    Name = "Conferences"
                },
                new()
                {
                    CategoryId = playGuid,
                    Name = "Plays"
                }
            };

            var mockCategoryRepository = new Mock<IAsyncRepository<Category>>();
            mockCategoryRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
                (Category category) =>
                {
                    categories.Add(category);
                    return category;
                });

            return mockCategoryRepository;
        }
        public static Mock<IEntityOneRepository> GetEntityOneRepository()
        {
            var entitiesOne = new List<Domain.Entities.EntityOne>
            {
                new()
                {
                    EntityOneId = 1, Name = "Entity One", Description = "The first entity.", TypeId = 1,
                    Price = 1.21M, CreatedBy = "Fred", CreatedDate = new DateTime(2001, 1, 1)
                },
                new()
                {
                    EntityOneId = 2, Name = "Entity Two", Description = "The second entity.", TypeId = 2,
                    Price = 1.22M, CreatedBy = "Fred", CreatedDate = new DateTime(2001, 1, 2)
                },
                new()
                {
                    EntityOneId = 3, Name = "Entity Three", Description = "The third entity.", TypeId = 3,
                    Price = 1.23M, CreatedBy = "Fred", CreatedDate = new DateTime(2001, 1, 3)
                },
            };

            var mockEntityOneRepository = new Mock<IEntityOneRepository>();

            mockEntityOneRepository.Setup(repo =>
                repo.GetPagedEntityOneList(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(
                    (int page, int size) =>
                    {
                        
                        return entitiesOne.Skip((page - 1) * size).Take(size).ToList();
                    }
            );

            mockEntityOneRepository.Setup(repo =>
                repo.AddAsync(It.IsAny<Domain.Entities.EntityOne>())).ReturnsAsync(
                (Domain.Entities.EntityOne entityOne) =>
                {
                    var nextId = entitiesOne.Count + 1;
                    entityOne.EntityOneId = nextId;
                    entitiesOne.Add(entityOne);
                    return entityOne;
                });

            mockEntityOneRepository.Setup(repo =>
                repo.GetByIntIdAsync(It.IsAny<int>())).ReturnsAsync(
                (int id) =>
                {
                    var foundEntity = entitiesOne.Find(ent => ent.EntityOneId == id);
                    return foundEntity;
                });
            
            mockEntityOneRepository.Setup(repo =>
                repo.UpdateAsync(It.IsAny<Domain.Entities.EntityOne>())).Callback(
                (Domain.Entities.EntityOne entityOne) =>
                {
                    var foundEntity = entitiesOne.Find(ent => ent.EntityOneId == entityOne.EntityOneId);
                    if (foundEntity != null)
                    {
                        foundEntity.Name = entityOne.Name;
                        foundEntity.Description = entityOne.Description;
                        foundEntity.Price = entityOne.Price;
                        foundEntity.LastModifiedBy = "Test";
                        foundEntity.LastModifiedDate = new DateTime(2010, 1, 2);
                    }
                });

            mockEntityOneRepository.Setup(repo =>
                repo.DeleteAsync((It.IsAny<Domain.Entities.EntityOne>()))).Callback(
                (Domain.Entities.EntityOne entityOne) =>
                {
                    var foundEntity = entitiesOne.Find(ent => ent.EntityOneId == entityOne.EntityOneId);
                    if (foundEntity != null)
                        entitiesOne.Remove(foundEntity);
                });

            return mockEntityOneRepository;
        }
    }
}