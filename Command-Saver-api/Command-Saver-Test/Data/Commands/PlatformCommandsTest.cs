namespace Command_Saver_Test.Data.Commands
{
    using Command_Saver_data.Commands;
    using Command_Saver_data.Models;
    using Command_Saver_data;
    using FakeItEasy;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class PlatformCommandsTest
    {
        private CommandSaverDbContext commandSaverDbContext = A.Fake<CommandSaverDbContext>();
        private Platform fakePlatform = A.Fake<Platform>();

        private void SetupFakePlatformsDbSet(IQueryable<Platform> fakeIQueryable)
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

            A.CallTo(() => commandSaverDbContext.Platforms).Returns(fakeDbSet);
        }


        private void SetupFakeCommandPlatformDbSet(IQueryable<CommandPlatform> fakeIQueryable)
        {
            var fakeDbSet = A.Fake<DbSet<CommandPlatform>>((d =>
                     d.Implements(typeof(IQueryable<CommandPlatform>))));

            A.CallTo(() => ((IQueryable<CommandPlatform>)fakeDbSet).GetEnumerator())
                .Returns(fakeIQueryable.GetEnumerator());

            A.CallTo(() => ((IQueryable<CommandPlatform>)fakeDbSet).Provider)
                .Returns(fakeIQueryable.Provider);

            A.CallTo(() => ((IQueryable<CommandPlatform>)fakeDbSet).Expression)
                .Returns(fakeIQueryable.Expression);

            A.CallTo(() => ((IQueryable<CommandPlatform>)fakeDbSet).ElementType)
               .Returns(fakeIQueryable.ElementType);

            A.CallTo(() => commandSaverDbContext.CommandPlatforms).Returns(fakeDbSet);
        }

        [Fact]
        public void CreateCommand_ShouldCreate_NewCommand()
        {
            //Arrange
            var fakeIQueryableBooks = new List<Platform>()
            {
                new Platform() { Id = 1},
                new Platform() { Id = 2},
                new Platform() { Id = 3},
                new Platform() { Id = 4},
                new Platform() { Id = 5},
            }
            .AsQueryable();

            SetupFakePlatformsDbSet(fakeIQueryableBooks);

            var commandCommands = new PlatformCommands(commandSaverDbContext);

            //Act
            var result = commandCommands.CreatePlatform(fakePlatform);

            //Assert
            A.CallTo(() => commandSaverDbContext.Platforms.Add(fakePlatform))
           .MustHaveHappenedOnceExactly();
            A.CallTo(() => commandSaverDbContext.SaveChanges())
               .MustHaveHappenedOnceExactly();
        }
    }
}
