namespace Command_Saver_Test.Data.Queries
{
    using Command_Saver_data;
    using Command_Saver_data.Models;
    using Command_Saver_data.Queries;
    using FakeItEasy;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CommandQueriesTest
    {
        private CommandSaverDbContext fakeDbContext = A.Fake<CommandSaverDbContext>();

        private void SetupFakeDbSet(IQueryable<Command> fakeIQueryable)
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

            A.CallTo(() => fakeDbContext.Commands).Returns(fakeDbSet);
        }

        [Fact]
        public void GetAllCommands_Should_Return_AllCommands()
        {
            // Arrange
            var fakeIQueryable = new List<Command>()
            {
                new Command() { Id = 1},
                new Command() { Id = 2},
                new Command() { Id = 3},
                new Command() { Id = 4},
                new Command() { Id = 5},
            }
            .AsQueryable();

            SetupFakeDbSet(fakeIQueryable);

            var commandQueries = new CommandQueries(fakeDbContext);

            var expectedCount = fakeIQueryable.Count();

            //Act
            var result = commandQueries.GetAllCommands();

            var actualCount = result.Count();

            //Assert
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public void GetCommandById_Should_Return_CommandWithId()
        {
            // Arrange
            var command = new Command() { Id = 1 };

            var fakeIQueryable = new List<Command> { command }.AsQueryable();

            SetupFakeDbSet(fakeIQueryable);

            var commandQueries = new CommandQueries(fakeDbContext);

            //Act
            var result = commandQueries.GetCommandById(1);

            //Assert
            Assert.Equal(result.Id, command.Id);
        }
    }
}
