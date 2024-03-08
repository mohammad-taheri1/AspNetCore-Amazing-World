using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourTube.Core.IServices;

namespace YourTube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YouTubeController : ControllerBase
    {
        private readonly IYouTubeClientService _youTubeClientService;

        public YouTubeController(IYouTubeClientService youTubeClientService)
        {
            _youTubeClientService = youTubeClientService;
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search([FromQuery] string q, [FromQuery] int maxResult = 50)
        {
            var result = await _youTubeClientService.SearchAsync(q, maxResult);

            return Ok(result);
        }

        [HttpGet]
        [Route("channel/{id}")]
        public async Task<IActionResult> SearchChannel([FromRoute] string id, [FromQuery] int maxResult = 50)
        {
            var result = await _youTubeClientService.SearchChannelAsync(id, maxResult);

            return Ok(result);
        }
    }
}
