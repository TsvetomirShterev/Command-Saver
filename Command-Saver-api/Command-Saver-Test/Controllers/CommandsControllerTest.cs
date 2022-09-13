namespace Command_Saver_Test.Controllers
{
    using Command_Saver_api.Controllers;
    using Command_Saver_data.Models;
    using Command_Saver_service.DTO;
    using Command_Saver_service.Services;
    using FakeItEasy;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;

    public class CommandsControllerTest
    {
        private CommandsController commandsController;
        private ICommandService commandService = A.Fake<ICommandService>();

        private void SetupController()
        {
            commandsController = new CommandsController(commandService);
        }

        [Fact]
        public void CreateCommand_ShouldCreate_Command()
        {
            //Arrange
            A.CallTo(() => commandService.CreateCommand(A<CreateCommandModel>.Ignored))
                .Returns(new Command());

            SetupController();

            var createCommandModel = new CreateCommandModel();

            //Act
            var result = commandsController.CreateCommand(createCommandModel);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<CreateCommandModel>>(result);
            Assert.IsType<CreatedResult>(result.Result);
        }

        [Fact]
        public void CreateCommand_ShouldNotCreate_Command_WhenModelIsNull()
        {
            //Arrange
            A.CallTo(() => commandService.CreateCommand(A<CreateCommandModel>.Ignored))
                .Returns(null);

            SetupController();

            var createCommandModel = new CreateCommandModel();

            //Act
            var result = commandsController.CreateCommand(createCommandModel);
            
            //Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public void GetAllCommands_Should_ReturnAllCommands()
        {
            //Arrange
            A.CallTo(() => commandService.GetAllCommands())
                .Returns(new List<ReadCommandModel>());

            SetupController();

            //Act
           var result = commandsController.GetAllCommands();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<ICollection<ReadCommandModel>>>(result);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetCommandById_ShouldReturn_OkObjectResult_WhenIdExists()
        {
            //Arrange
            var bookId = 5;

            A.CallTo(() => commandService.GetCommandById(bookId))
                .Returns(new ReadCommandModel() { Id = bookId });

            SetupController();

            //Act
            var result = commandsController.GetCommandById(bookId);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<ActionResult<ReadCommandModel>>(result);
        }

        [Fact]
        public void GetCommandById_ShouldReturn_NotFound_WhenId_DoesNotExist()
        {
            //Arrange
            var bookId = 5;

            A.CallTo(() => commandService.GetCommandById(bookId))
                .Returns(null);

            SetupController();

            //Act
            var result = commandsController.GetCommandById(bookId);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
            Assert.IsType<ActionResult<ReadCommandModel>>(result);
        }
    }
}
