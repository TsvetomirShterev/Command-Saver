namespace Command_Saver_data.Queries
{
    using Command_Saver_data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class PlatformQueries : IPlatformQueries
    {
        private readonly CommandSaverDbContext commandSaverDbContext;
        public PlatformQueries(CommandSaverDbContext commandSaverDbContext)
        {
            this.commandSaverDbContext = commandSaverDbContext;
        }

        public ICollection<Platform> GetAllPlatforms()
        {
            var allPlatforms = commandSaverDbContext
                .Platforms
                .Include(p => p.Commands)
                    .ThenInclude(c => c.Command)
                .ToArray();

            return allPlatforms;
        }

        public Platform GetPlatformById(int id)
        {
            var platform = commandSaverDbContext
               .Platforms
               .Include(p => p.Commands)
                   .ThenInclude(c => c.Command)
               .ToArray()
               .FirstOrDefault(p => p.Id == id);

            return platform;
        }

        public List<Platform> GetExistingPlatforms(IEnumerable<string> platforms)
        {
            var existingGenres = commandSaverDbContext.Platforms
           .Where(p => platforms.Contains(p.Name))
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
