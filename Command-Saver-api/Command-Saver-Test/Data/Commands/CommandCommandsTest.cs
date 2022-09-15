namespace Command_Saver_Test.Data.Commands
{
    using Command_Saver_data;
    using Command_Saver_data.Commands;
    using Command_Saver_data.Models;
    using FakeItEasy;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CommandCommandsTest
    {
        private CommandSaverDbContext commandSaverDbContext = A.Fake<CommandSaverDbContext>();
        private Command fakeCommand = A.Fake<Command>();

        private void SetupFakeCommandsDbSet(IQueryable<Command> fakeIQueryable)
        {
            var fakeDbSet = A.Fake<DbSet<Command>>((d =>
                     d.Implements(typeof(IQueryable<Command>))));

            A.CallTo(() => ((IQueryable<Command>)fakeDbSet).GetEnumerator())
                .Returns(fakeIQueryable.GetEnumerator());

            A.CallTo(() => ((IQueryable<Command>)fakeDbSet).Provider)
                .Returns(fakeIQueryable.Provider);

            A.CallTo(() => ((IQueryable<Command>)fakeDbSet).Expression)
                .Returns(fakeIQueryable.Expression);

            A.CallTo(() => ((IQueryable<Command>)fakeDbSet).ElementType)
               .Returns(fakeIQueryable.ElementType);

            A.CallTo(() => commandSaverDbContext.Commands).Returns(fakeDbSet);
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
            var fakeIQueryableBooks = new List<Command>()
            {
                new Command() { Id = 1},
                new Command() { Id = 2},
                new Command() { Id = 3},
                new Command() { Id = 4},
                new Command() { Id = 5},
            }
            .AsQueryable();

            SetupFakeCommandsDbSet(fakeIQueryableBooks);

            var commandCommands = new CommandCommands(commandSaverDbContext);

            //Act
            var result = commandCommands.CreateCommand(fakeCommand);

            //Assert
            A.CallTo(() => commandSaverDbContext.Commands.Add(fakeCommand))
           .MustHaveHappenedOnceExactly();
            A.CallTo(() => commandSaverDbContext.SaveChanges())
               .MustHaveHappenedOnceExactly();
        }
    }
}
