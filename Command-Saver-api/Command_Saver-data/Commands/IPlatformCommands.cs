namespace Command_Saver_data.Commands
{
    using Command_Saver_data.Models;

    public interface IPlatformCommands
    {
        Platform CreatePlatform(Platform command);
    }
}
