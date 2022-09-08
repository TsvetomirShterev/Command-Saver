namespace Command_Saver_api.Controllers
{
    using Command_Saver_service.DTO;
    using Command_Saver_service.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandService commandService;
        public CommandsController(ICommandService commandService)
        {
            this.commandService = commandService;
        }

        [HttpPost]
        public ActionResult<CreateCommandModel> CreateCommand(CreateCommandModel createCommandRequest)
        {
            var createdCommand = commandService.CreateCommand(createCommandRequest);

            if (createdCommand is null)
            {
                return BadRequest();
            }

            return Created("api/[controller]", createCommandRequest);
        }


        [HttpGet]
        public ActionResult<ReadCommandModel> GetAllCommands()
        {
            var commands = commandService.GetAllCommands();

            return Ok(commands);
        }

        [HttpGet("{commandId}", Name = "GetCommandById")]
        public ActionResult<ReadCommandModel> GetCommandById(int commandId)
        {
            var command = commandService.GetCommandById(commandId);

            if (command is null)
            {
                return NotFound();
            }

            return Ok(command);
        }
    }
}
