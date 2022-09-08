namespace Command_Saver_service.Services
{
    using Command_Saver_data.Models;
    using Command_Saver_service.DTO;

    public interface ICommandService
    {
        Command CreateCommand(CreateCommandModel createCommandRequest);

        ICollection<ReadCommandModel> GetAllCommands();

        ReadCommandModel GetCommandById(int commandId);
    }
}
