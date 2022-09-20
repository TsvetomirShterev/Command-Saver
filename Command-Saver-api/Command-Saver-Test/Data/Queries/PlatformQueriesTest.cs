namespace Command_Saver_Test.Data.Queries
{
    using Command_Saver_data.Queries;
    using Command_Saver_data;
    using FakeItEasy;
    using Microsoft.EntityFrameworkCore;
    using Xunit;
    using Command_Saver_data.Models;

    public class PlatformQueriesTest
    {
        private CommandSaverDbContext fakeDbContext = A.Fake<CommandSaverDbContext>();

        private void SetupFakeDbSet(IQueryable<Platform> fakeIQueryable)
        {
            var fakeDbSet = A.Fake<DbSet<Platform>>((d =>
                     d.Implements(typeof(IQueryable<Platform>))));

            A.CallTo(() => ((IQueryable<Platform>)fakeDbSet).GetEnumerator())
                .Returns(fakeIQueryable.GetEnumerator());

            A.CallTo(() => ((IQueryable<Platform>)fakeDbSet).Provider)
                .Returns(fakeIQueryable.Provider);

            A.CallTo(() => ((IQueryable<Platform>)fakeDbSet).Expression)
                .Returns(fakeIQueryable.Expression);

            A.CallTo(() => ((IQueryable<Platform>)fakeDbSet).ElementType)
               .Returns(fakeIQueryable.ElementType);

            A.CallTo(() => fakeDbContext.Platforms).Returns(fakeDbSet);
        }

        [Fact]
        public void GetAllPlatforms_Should_Return_AllPlatforms()
        {
            // Arrange
            var fakeIQueryable = new List<Platform>()
            {
                new Platform() { Id = 1},
                new Platform() { Id = 2},
                new Platform() { Id = 3},
                new Platform() { Id = 4},
                new Platform() { Id = 5},
            }
            .AsQueryable();

            SetupFakeDbSet(fakeIQueryable);

            var platformQueries = new PlatformQueries(fakeDbContext);

            var expectedCount = fakeIQueryable.Count();

            //Act
            var result = platformQueries.GetAllPlatforms();

            var actualCount = result.Count();

            //Assert
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public void GetPlatformById_Should_Return_PlatformWithId()
        {
            // Arrange
            var platform = new Platform() { Id = 1 };

            var fakeIQueryable = new List<Platform> { platform }.AsQueryable();

            SetupFakeDbSet(fakeIQueryable);

            var platformQueries = new PlatformQueries(fakeDbContext);

            //Act
            var result = platformQueries.GetPlatformById(1);

            //Assert
            Assert.Equal(result.Id, platform.Id);
        }
    }
}
