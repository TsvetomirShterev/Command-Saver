namespace Command_Saver_data.Commands
{
    using Command_Saver_data.Models;

    public interface ICommandCommands
    {
        Command CreateCommand(Command command);
    }
}
