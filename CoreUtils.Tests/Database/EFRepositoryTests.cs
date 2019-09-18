namespace System1Group.Lib.CoreUtils.Tests.Database
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System1Group.Lib.CoreUtils.Database;

    [TestFixture]
    public class EFRepositoryTests
    {
        private FakeDbContext context;
        private DbContextOptions<FakeDbContext> options;
        private IRepository<FakeTable> fakeTableRepository;
        private List<FakeTable> fakeTableData;

        [SetUp]
        public async Task SetUp()
        {
            this.options = new DbContextOptionsBuilder<FakeDbContext>()
                .UseInMemoryDatabase(databaseName: nameof(EFRepositoryTests))
                .Options;

            this.context = new FakeDbContext(this.options);

            this.fakeTableRepository = new EfRepository<FakeTable>(this.context);

            this.fakeTableData = new List<FakeTable>();
            this.fakeTableData.AddRange(new List<FakeTable>()
            {
                new FakeTable
                {
                    Id = 1,
                    Name = "Name1"
                },
                new FakeTable
                {
                    Id = 2,
                    Name = "Name2"
                }
            });

            await this.context.FakeTable.AddRangeAsync(this.fakeTableData);

            await this.context.SaveChangesAsync();
        }

        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
            this.context.Dispose();
        }

        [Test]
        public async Task Get()
        {
            var result = await this.fakeTableRepository.Get(1);

            result.Name.Should().Be("Name1");
        }

        [Test]
        public async Task GetAll()
        {
            var result = await this.fakeTableRepository.GetAll().ToListAsync();

            result.Count.Should().Be(this.fakeTableData.Count);
        }

        [Test]
        public async Task Add()
        {
            await this.fakeTableRepository.Add(new FakeTable { Id = 3, Name = "Name3" });
            await this.fakeTableRepository.SaveChangesAsync();

            var result = await this.fakeTableRepository.Get(3);
            result.Should().NotBeNull();
        }

        [Test]
        public async Task AddRange()
        {
            this.fakeTableRepository.AddRange(new List<FakeTable> { new FakeTable { Id = 3, Name = "Name3" }, new FakeTable { Id = 4, Name = "Name4" } });
            await this.fakeTableRepository.SaveChangesAsync();

            var result = await this.fakeTableRepository.GetAll().ToListAsync();
            result.Count.Should().Be(this.fakeTableData.Count + 2);
        }

        [Test]
        public async Task Delete()
        {
            var data = await this.fakeTableRepository.Get(1);
            this.fakeTableRepository.Delete(data);
            await this.fakeTableRepository.SaveChangesAsync();

            var result = await this.fakeTableRepository.Get(1);
            result.Should().BeNull();
        }

        [Test]
        public async Task Update()
        {
            var data = await this.fakeTableRepository.Get(1);

            data.Name = "New Name";

            this.fakeTableRepository.Update(data);
            await this.fakeTableRepository.SaveChangesAsync();

            var result = await this.fakeTableRepository.Get(1);
            result.Name.Should().Be("New Name");
        }
    }
}
