namespace Command_Saver_service.Services
{
    using AutoMapper;
    using Command_Saver_data.Commands;
    using Command_Saver_data.Models;
    using Command_Saver_data.Queries;
    using Command_Saver_service.DTO;
    using System;
    using System.Collections.Generic;

    public class CommandService : ICommandService
    {
        private readonly ICommndCommands commndCommands;
        private readonly ICommandQueries commandQueries;
        private readonly IPlatformQueries platformQueries;
        private readonly IMapper mapper;

        public CommandService(ICommandQueries commandQueries, ICommndCommands commndCommands, IMapper mapper, IPlatformQueries platformQueries)
        {
            this.commandQueries = commandQueries;
            this.commndCommands = commndCommands;
            this.mapper = mapper;
            this.platformQueries = platformQueries;
        }

        public CreateCommandModel CreateCommand(CreateCommandModel createCommandRequest)
        {
            var command = mapper.Map<Command>(createCommandRequest);

            var commandPlatforms = new List<CommandPlatform>();

            var existingPLatforms = platformQueries.GetExistingPlatforms(createCommandRequest.Platforms);

            AddCommandsToExistingPlatform(command, commandPlatforms, existingPLatforms);

            var newPlatforms = platformQueries.GetNewPlatforms(createCommandRequest.Platforms, existingPLatforms);

            AddBooksToNewGenres(command, commandPlatforms, newPlatforms);

            command.Platforms = commandPlatforms;

            var result = commndCommands.CreateCommand(command);

            return mapper.Map<CreateCommandModel>(result);
        }


        public ICollection<ReadCommandModel> GetAllCommands()
        {
            var commandsFromDb = commandQueries.GetAllCommands();

            var commands = mapper.Map<List<ReadCommandModel>>(commandsFromDb);

            return commands;
        }

        public ReadCommandModel GetCommandById(int commandId)
        {
            var commandFromDb = commandQueries.GetCommandById(commandId);

            var command = mapper.Map<ReadCommandModel>(commandFromDb);

            return command;
        }

        private void AddCommandsToExistingPlatform(Command command, List<CommandPlatform> commandPlatforms, List<Platform> existingPLatforms)
        {
            existingPLatforms
            .ForEach(platform => commandPlatforms.Add(new CommandPlatform()
            {
                Command = command,
                Platform = platform,
            }));
        }

        private void AddBooksToNewGenres(Command command, List<CommandPlatform> commandPlatforms, List<string> newPlatforms)
        {
            newPlatforms
             .ForEach(platformName => commandPlatforms.Add(new CommandPlatform()
             {
                 Command = command,
                 Platform = new Platform() { Name = platformName },
             }));
        }
    }
}
