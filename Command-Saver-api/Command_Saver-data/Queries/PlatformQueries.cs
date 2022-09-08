namespace Command_Saver_data.Queries
{
    using Command_Saver_data.Models;
    using System.Collections.Generic;

    public class PlatformQueries : IPlatformQueries
    {
        private readonly CommandSaverDbContext commandSaverDbContext;
        public PlatformQueries(CommandSaverDbContext commandSaverDbContext)
        {
            this.commandSaverDbContext = commandSaverDbContext;
        }

        public List<Platform> GetExistingPlatforms(IEnumerable<string> platforms)
        {
            var existingGenres = commandSaverDbContext.Platforms
           .Where(p => platforms.Contains(p.Name))
           //.Select(p => p)
           .ToList();

            return existingGenres;
        }

        public List<string> GetNewPlatforms(IEnumerable<string> platforms, List<Platform> existingPlatforms)
        {
            return platforms
            .Select(x => x)
            .Except(existingPlatforms.Select(a => a.Name))
            .ToList();
        }
    }
}
