namespace Command_Saver_Test.Controllers
{
    using Command_Saver_api.Controllers;
    using Command_Saver_data.Models;
    using Command_Saver_service.DTO;
    using Command_Saver_service.Services;
    using FakeItEasy;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;

    public class PlatformsControllerTest
    {
        private PlatformsController platformsController;
        private IPlatformService platformService = A.Fake<IPlatformService>();

        private void SetupController()
        {
            platformsController = new PlatformsController(platformService);
        }

        [Fact]
        public void CreatePlatform_Shouldreturn_CreatedResult()
        {
            //Arrange
            A.CallTo(() => platformService.CreatePlatform(A<CreatePlatformModel>.Ignored))
                .Returns(new Platform());

            SetupController();

            var createPlatformModel = new CreatePlatformModel();

            //Act 
            var result = platformsController.CreatePlatform(createPlatformModel);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<CreatePlatformModel>>(result);
            Assert.IsType<CreatedResult>(result.Result);
        }

        [Fact]
        public void CreatePlatform_ShouldNotCreate_Platform_WhenModelIsNull()
        {
            //Arrange
            A.CallTo(() => platformService.CreatePlatform(A<CreatePlatformModel>.Ignored))
                .Returns(null);

            SetupController();

            var createPlatformModel = new CreatePlatformModel();

            //Act
            var result = platformsController.CreatePlatform(createPlatformModel);

            //Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public void GetAllPlatforms_Should_ReturnAllPlatforms()
        {
            //Arrange
            A.CallTo(() => platformService.GetAllPlatforms())
                .Returns(new List<ReadPlatformModel>());

            SetupController();

            //Act
            var result = platformsController.GetAllPlatforms();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<ICollection<ReadPlatformModel>>>(result);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetPlatformById_ShouldReturn_OkObjectResult_WhenIdExists()
        {
            //Arrange
            var platformId = 5;

            A.CallTo(() => platformService.GetPlatformById(platformId))
                .Returns(new ReadPlatformModel() { Id = platformId });

            SetupController();

            //Act
            var result = platformsController.GetPlatformById(platformId);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<ActionResult<ReadPlatformModel>>(result);
        }

        [Fact]
        public void GetPlatformById_ShouldReturn_NotFound_WhenId_DoesNotExist()
        {
            //Arrange
            var platformId = 5;

            A.CallTo(() => platformService.GetPlatformById(platformId))
                .Returns(null);

            SetupController();

            //Act
            var result = platformsController.GetPlatformById(platformId);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
            Assert.IsType<ActionResult<ReadPlatformModel>>(result);
        }
    }
}
