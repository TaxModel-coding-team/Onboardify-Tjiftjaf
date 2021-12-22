using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgressionService.Logic;
using Microsoft.AspNetCore.Mvc;
using ProgressionService.ViewModels;

namespace ProgressionService.Controllers
{
    [Route("achievements")]
    [ApiController]
    public class AchievementController : Controller
    {
        private readonly AchievementLogic _logic;

        public AchievementController(AchievementLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public IActionResult GetAchievements()
        {
            ICollection<AchievementViewModel> achievements = _logic.GetAchievements();
            return Ok(achievements);
        }
    }
}
