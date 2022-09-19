namespace Command_Saver_data.Commands
{
    using Command_Saver_data.Models;

    public class PlatformCommands : IPlatformCommands
    {
        private readonly CommandSaverDbContext commandSaverDbContext;

        public PlatformCommands(CommandSaverDbContext commandSaverDbContext)
        {
            this.commandSaverDbContext = commandSaverDbContext;
        }

        public Platform CreatePlatform(Platform platform)
        {
            commandSaverDbContext.Platforms.Add(platform);
            commandSaverDbContext.SaveChanges();

            return platform;
        }
    }
}
