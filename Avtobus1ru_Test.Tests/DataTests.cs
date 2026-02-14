using Avtobus1ru_Test.Data;
using Avtobus1ru_Test.Data.Entities;
using Avtobus1ru_Test.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Avtobus1ru_Test.Tests
{
    public class DataTests
    {
        static LinkEntity emptyEntity = new LinkEntity()
        {
            Id = 1,
            LongURL = "",
            ShortURLKey = "",
            CreationDate = new DateTime(2026, 2, 14, 12, 0, 0),
            ClickCount = 0
        };

        static LinkEntity testEntity = new LinkEntity()
        {
            Id = 1,
            LongURL = "https://www.fake-url.com",
            ShortURLKey = "ab593c12-0188-400f-8764-261e9d3efd35",
            CreationDate = new DateTime(2026, 2, 14, 12, 0, 0),
            ClickCount = 1
        };

        static List<LinkEntity> linkEntities = new List<LinkEntity> { testEntity };


        private DataContext GetDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            return new DataContext(optionsBuilder.Options);
        }

        private LinkRepository GetRepository(DataContext context)
        {
            return new LinkRepository(context);
        }


        [Fact]
        public async Task CreateTest()
        {
            var context = GetDbContext();
            var repository = GetRepository(context);

            await repository.CreateAsync(testEntity);

            Assert.Single(context.Links);
        }

        [Fact]
        public async Task GetAllTest()
        {
            var repository = GetRepository(GetDbContext());

            await repository.CreateAsync(testEntity);
            var result = await repository.GetAllAsync();

            Assert.Equal(result, linkEntities);
        }

        [Fact]
        public async Task GetByIdTest()
        {
            var repository = GetRepository(GetDbContext());

            await repository.CreateAsync(testEntity);
            var result = await repository.GetByIdAsync(testEntity.Id);

            Assert.Equal(result, testEntity);
        }

        [Fact]
        public async Task GetLongFromShortTest()
        {
            var repository = GetRepository(GetDbContext());

            await repository.CreateAsync(testEntity);
            var result = await repository.GetLongFromShortAsync(testEntity.ShortURLKey);

            Assert.Equal(result, testEntity);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var repository = GetRepository(GetDbContext());

            await repository.CreateAsync(emptyEntity);
            await repository.UpdateAsync(testEntity);
            var result = await repository.GetByIdAsync(testEntity.Id);

            Assert.Equal(result, testEntity);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var context = GetDbContext();
            var repository = GetRepository(context);

            await repository.CreateAsync(testEntity);
            await repository.DeleteAsync(testEntity.Id);

            Assert.Empty(context.Links);
        }
    }
}
