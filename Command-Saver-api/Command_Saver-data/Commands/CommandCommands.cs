namespace Command_Saver_data.Commands
{
    using Command_Saver_data.Models;

    public class CommandCommands : ICommndCommands
    {
        private readonly CommandSaverDbContext commandSaverDbContext;

        public CommandCommands(CommandSaverDbContext commandSaverDbContext)
        {
            this.commandSaverDbContext = commandSaverDbContext;
        }

        public Command CreateCommand(Command command)
        {
            commandSaverDbContext.Commands.Add(command); 
            commandSaverDbContext.SaveChanges();
            return command;
        }
    }
}
