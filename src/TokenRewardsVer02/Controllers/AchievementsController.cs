using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TokenRewardsVer02.Controllers
{
    [Route("api/[controller]")]
    public class AchievementsController : Controller
    {
        private IAchievementService _service;

        // GET: api/achievements
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IEnumerable<Achievement> Get()
        {
            return _service.GetAllAchievements();
        }

        // GET api/achievements/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetByAchievementId(id));
        }

        // POST api/achievements
        [HttpPost]
        public IActionResult Post([FromBody]Achievement achievement)
        {
            _service.SaveAchievement(achievement);
            return Ok(achievement);
        }

        // DELETE api/achievements/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteAchievement(id);
            return Ok();
        }

        public AchievementsController(IAchievementService service)
        {
            this._service = service;
        }
    }
}
