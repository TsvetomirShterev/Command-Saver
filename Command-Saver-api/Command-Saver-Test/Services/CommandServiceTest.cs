namespace Command_Saver_Test.Services
{
    using AutoMapper;
    using Command_Saver_data.Commands;
    using Command_Saver_data.Models;
    using Command_Saver_data.Queries;
    using Command_Saver_service.DTO;
    using Command_Saver_service.Profiles;
    using Command_Saver_service.Services;
    using FakeItEasy;
    using System.Text.Json;
    using Xunit;

    public class CommandServiceTest
    {
        private ICommandService commandService;
        private readonly IMapper mapper;
        private readonly ICommandQueries commandQueries = A.Fake<ICommandQueries>();
        private readonly ICommandCommands commandCommands = A.Fake<ICommandCommands>();
        private readonly IPlatformQueries platformQueries = A.Fake<IPlatformQueries>();
        private readonly ICollection<Command> commands = A.Fake<ICollection<Command>>();
        private readonly ICollection<ReadCommandModel> readCommandModels = A.Fake<ICollection<ReadCommandModel>>();


        public CommandServiceTest()
        {
            var config = new MapperConfiguration(config =>
            {
                config.AddProfile(new CommandsProfile());
            });

            mapper = new Mapper(config);
        }

        private void SetupService()
        {
            commandService = new CommandService(commandQueries, commandCommands, mapper, platformQueries);
        }

        [Fact]
        public void CreateCommand_ShouldCreate_NewCommand()
        {
            //Arrange
            A.CallTo(() => commandCommands.CreateCommand(A<Command>.Ignored));

            SetupService();

            var commandRequest = new CreateCommandModel();

            var expected = new Command();

            //Act
            var actual = commandService.CreateCommand(commandRequest);

            //Assert
            A.CallTo(() => commandCommands.CreateCommand(A<Command>.Ignored))
                .MustHaveHappenedOnceExactly();
            Assert.NotNull(actual);
            Assert.Equal(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
        }

        [Fact]
        public void GetAllCommands_ShouldGet_AllCommands()
        {
            //Arrange
            SetupService();

            A.CallTo(() => commandQueries.GetAllCommands())
                .Returns(commands);


            //Act
            var result = commandService.GetAllCommands();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(readCommandModels, result);
        }

        [Fact]
        public void GetCommandById_ShouldGet_CommandWithId_IfIdExists()
        {
            //Arrange
            var commandId = 5;

            SetupService();

            A.CallTo(() => commandQueries.GetCommandById(A<int>.Ignored))
                .Returns(new Command());

            //Act
            var result = commandService.GetCommandById(commandId);

            //Assert
            Assert.NotNull(result);
            A.CallTo(() => commandQueries.GetCommandById(commandId))
                .MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void GetCommandById_ShouldGet_CommandWithId_IfIdDoesNotExists()
        {
            //Arrange
            var commandId = 5;

            SetupService();

            A.CallTo(() => commandQueries.GetCommandById(A<int>.Ignored))
                .Returns(null);

            //Act
            var result = commandService.GetCommandById(commandId);

            //Assert
            A.CallTo(() => commandQueries.GetCommandById(commandId))
                .MustHaveHappened();
        }
    }
}
