namespace Command_Saver_service.Services
{
    using AutoMapper;
    using Command_Saver_data.Commands;
    using Command_Saver_data.Models;
    using Command_Saver_data.Queries;
    using Command_Saver_service.DTO;
    using System.Collections.Generic;

    public class PlatformService : IPlatformService
    {
        private readonly IPlatformQueries platformQueries;
        private readonly IPlatformCommands platformCommands;
        private readonly IMapper mapper;

        public PlatformService(IPlatformQueries platformQueries, IPlatformCommands platformCommands, IMapper mapper)
        {
            this.platformQueries = platformQueries;
            this.platformCommands = platformCommands;
            this.mapper = mapper;
        }

        public Platform CreatePlatform(CreatePlatformModel createPlatformRequest)
        {
            var platform = mapper.Map<Platform>(createPlatformRequest);

            var result = platformCommands.CreatePlatform(platform);

            return result;
        }

        public ICollection<ReadPlatformModel> GetAllPlatforms()
        {
            var platformsFromDb = platformQueries.GetAllPlatforms();

            var readPlatformModels = mapper.Map<ReadPlatformModel[]>(platformsFromDb);

            return readPlatformModels;
        }

        public ReadPlatformModel GetPlatformById(int platformId)
        {
            throw new NotImplementedException();
        }
    }
}
