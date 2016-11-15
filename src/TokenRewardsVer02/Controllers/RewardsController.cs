using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TokenRewardsVer02.Controllers
{
    [Route("api/[controller]")]
    public class RewardsController : Controller
    {
        private IRewardService _service;

        // GET: api/rewards
        [HttpGet]
        public IEnumerable<Reward> Get()
        {
            return _service.GetAllRewards();
        }

        // GET api/rewards/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetRewardById(id));
        }

        // POST api/rewards
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Post([FromBody]Reward reward)
        {
            _service.SaveReward(reward);
            return Ok(reward);
        }

        // DELETE api/rewards/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Delete(int id)
        {
            _service.DeleteReward(id);
            return Ok();
        }


        public RewardsController(IRewardService service)
        {
            this._service = service;
        }
    }
}
