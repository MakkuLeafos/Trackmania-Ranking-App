using Microsoft.AspNetCore.Mvc;

namespace TM_RankingApp_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RankingController
    {
        private readonly ILogger<RankingController> _logger;
        public RankingController(ILogger<RankingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetRanking")]
        public bool GetRanking()
        {
            _logger.LogInformation("GetRanking called");
            return true;
        }
    }
}
