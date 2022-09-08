namespace Command_Saver_service.Profiles
{
    using AutoMapper;
    using Command_Saver_data.Models;
    using Command_Saver_service.DTO;

    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, ReadCommandModel>()
                .ForMember(x => x.Platforms, opt => opt.MapFrom(x => x.Platforms.Select(y => y.Platform.Name).ToArray()));

            CreateMap<CreateCommandModel, Command>()
                .ForMember(x => x.Platforms, opt => opt.Ignore());

            CreateMap<Command, CreateCommandModel>()
               .ForMember(x => x.Platforms, opt => opt.MapFrom(x => x.Platforms.Select(y => y.Platform.Name).ToArray()));
        }
    }
}
