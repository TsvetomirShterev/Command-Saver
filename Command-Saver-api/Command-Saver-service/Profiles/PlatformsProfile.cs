namespace Command_Saver_service.Profiles
{
    using AutoMapper;
    using Command_Saver_data.Models;
    using Command_Saver_service.DTO;

    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            CreateMap<CreatePlatformModel, Platform>();

            CreateMap<Platform, ReadPlatformModel>()
                .ForMember(x => x.Commands, opt => opt.MapFrom(x => x.Commands.Select(y => y.Command.Goal + " : " + y.Command.Line).ToArray())); ;
        }
    }
}
