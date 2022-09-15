﻿namespace Command_Saver_data.Queries
{
    using Command_Saver_data.Models;

    public interface IPlatformQueries
    {
        List<Platform> GetExistingPlatforms(IEnumerable<string> platforms);

        List<string> GetNewPlatforms(IEnumerable<string> platforms, List<Platform> existingPlatforms);
    }
}
