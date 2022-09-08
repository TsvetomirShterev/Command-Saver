namespace Command_Saver_data.Queries
{
    using Command_Saver_data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class CommandQueries : ICommandQueries
    {
        private readonly CommandSaverDbContext commandSaverDbContext;

        public CommandQueries(CommandSaverDbContext commandSaverDbContext)
        {
            this.commandSaverDbContext = commandSaverDbContext;
        }

        public ICollection<Command> GetAllCommands()
        {
            var allCommands = commandSaverDbContext
                .Commands
                .Include(c => c.Platforms)
                    .ThenInclude(p => p.Platform)
                .ToArray();

            return allCommands;
        }

        public Command GetCommandById(int id)
        {
            var command = commandSaverDbContext.Commands.FirstOrDefault(c => c.Id == id);

            return command;
        }
    }
}
