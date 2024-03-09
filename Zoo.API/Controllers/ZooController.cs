using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zoo.Core.Interfaces;

namespace Zoo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZooController : ControllerBase
    {
        private readonly IZooService _zooService;
        private readonly ILogger<ZooController> _logger;
        public ZooController(ILogger<ZooController> logger, IZooService zooService)
        {
            _zooService = zooService;
            _logger = logger;
        }

        [HttpGet("cost")]
        public async Task<IActionResult> GetCostAsync(int numDays)
        {
            return Ok(await _zooService.CalculateCostAsync(numDays));
        }
    }
}
