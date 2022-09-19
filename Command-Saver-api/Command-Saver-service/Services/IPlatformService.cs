namespace Command_Saver_service.Services
{
    using Command_Saver_data.Models;
    using Command_Saver_service.DTO;
    using System.Collections.Generic;


    public interface IPlatformService
    {
        Platform CreatePlatform(CreatePlatformModel createPlatformRequest);

        ICollection<ReadPlatformModel> GetAllPlatforms();

        ReadPlatformModel GetPlatformById(int platformId);
    }
}
