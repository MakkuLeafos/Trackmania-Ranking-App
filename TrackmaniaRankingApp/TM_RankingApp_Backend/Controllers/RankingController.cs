using Microsoft.AspNetCore.Mvc;
using TM_RankingApp_Backend.Classes;
using TM_RankingApp_Backend.Models;

namespace TM_RankingApp_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RankingController
    {
        DataManager dataManager = new DataManager();

        private readonly ILogger<RankingController> _logger;
        public RankingController(ILogger<RankingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetEventList")]
        public List<TMEvent> GetEvents()
        {

            _logger.LogInformation("GetEvents called");
            return dataManager.GetEventList();
        }

        [HttpGet("GetLeaderboard")]
        public List<TMLeaderboardEntry> GetLeaderboard() 
        {
            _logger.LogInformation("GetLeaderboard called");
            return dataManager.GetLeaderboard();
        }
    }
}
