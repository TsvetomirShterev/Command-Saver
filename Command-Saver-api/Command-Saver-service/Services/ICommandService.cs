namespace Command_Saver_service.Services
{
    using Command_Saver_service.DTO;

    public interface ICommandService
    {
        CreateCommandModel CreateCommand(CreateCommandModel createCommandRequest);

        ICollection<ReadCommandModel> GetAllCommands();

        ReadCommandModel GetCommandById(int commandId);
    }
}
