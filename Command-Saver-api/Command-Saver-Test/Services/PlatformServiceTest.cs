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

    public class PlatformServiceTest
    {
        private IPlatformService platformService;
        private readonly IMapper mapper;
        private readonly IPlatformQueries platformQueries = A.Fake<IPlatformQueries>();
        private readonly IPlatformCommands platformCommands = A.Fake<IPlatformCommands>();
        private readonly ICollection<Platform> platforms = A.Fake<ICollection<Platform>>();
        private readonly ICollection<ReadPlatformModel> readPlatfomModels = A.Fake<ICollection<ReadPlatformModel>>();


        public PlatformServiceTest()
        {
            var config = new MapperConfiguration(config =>
            {
                config.AddProfile(new PlatformsProfile());
            });

            mapper = new Mapper(config);
        }

        private void SetupService()
        {
            platformService = new PlatformService(platformQueries, platformCommands, mapper);
        }

        [Fact]
        public void CreateCommand_ShouldCreate_NewCommand()
        {
            //Arrange
            A.CallTo(() => platformCommands.CreatePlatform(A<Platform>.Ignored));

            SetupService();

            var platformRequest = new CreatePlatformModel();

            var expected = new Platform();

            //Act
            var actual = platformService.CreatePlatform(platformRequest);

            //Assert
            A.CallTo(() => platformCommands.CreatePlatform(A<Platform>.Ignored))
                .MustHaveHappenedOnceExactly();
            Assert.NotNull(actual);
            Assert.Equal(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
        }

        [Fact]
        public void GetAllPlatforms_ShouldGet_AllPlatforms()
        {
            //Arrange
            SetupService();

            A.CallTo(() => platformQueries.GetAllPlatforms())
                .Returns(platforms);


            //Act
            var result = platformService.GetAllPlatforms();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(readPlatfomModels, result);
        }

        [Fact]
        public void GetPlatformById_ShouldGet_PlatformWithId_IfIdExists()
        {
            //Arrange
            var platformId = 5;

            SetupService();

            A.CallTo(() => platformQueries.GetPlatformById(A<int>.Ignored))
                .Returns(new Platform());

            //Act
            var result = platformService.GetPlatformById(platformId);

            //Assert
            Assert.NotNull(result);
            A.CallTo(() => platformQueries.GetPlatformById(platformId))
                .MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void GetPlatformById_ShouldGet_PlatformWithId_IfIdDoesNotExists()
        {
            //Arrange
            var platformId = 5;

            SetupService();

            A.CallTo(() => platformQueries.GetPlatformById(A<int>.Ignored))
                .Returns(null);

            //Act
            var result = platformService.GetPlatformById(platformId);

            //Assert
            A.CallTo(() => platformQueries.GetPlatformById(platformId))
                .MustHaveHappened();
        }
    }
}
