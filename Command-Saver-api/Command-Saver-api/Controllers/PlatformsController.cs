namespace Command_Saver_api.Controllers
{
    using Command_Saver_service.DTO;
    using Command_Saver_service.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformService platformService;

        public PlatformsController(IPlatformService platformService)
        {
            this.platformService = platformService;
        }

        [HttpPost]
        public ActionResult<CreatePlatformModel> CreatePlatform([FromForm] CreatePlatformModel createPlatformRequest)
        {
            var createdPlatform = platformService.CreatePlatform(createPlatformRequest);

            if (createdPlatform is null)
            {
                return BadRequest();
            }

            return Created("api/[controller]", createPlatformRequest);
        }

        [HttpGet]
        public ActionResult<ICollection<ReadPlatformModel>> GetAllPlatforms()
        {
            var allPlatforms = platformService.GetAllPlatforms();

            return Ok(allPlatforms);
        }

        [HttpGet("{platformId}", Name = "GetPlatformById")]
        public ActionResult<ReadPlatformModel> GetPlatformById(int platformId)
        {
            var platform = platformService.GetPlatformById(platformId);

            if (platform is null)
            {
                return NotFound();
            }

            return Ok(platform);
        }
    }
}
