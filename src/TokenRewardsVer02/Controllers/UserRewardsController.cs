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
    public class UserRewardsController : Controller
    {
        private IUserRewardService _service;

        [HttpGet("GetRewards/")]
        public IActionResult GetRewards()
        {
            string userName = this.User.Identity.Name;
            var list = _service.GetRewardsByUserName(userName);
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserRewards userRewards)
        {
            string userName = this.User.Identity.Name;
            _service.ClaimReward(userName, userRewards.RewardId);
            return Ok();
        }

        public UserRewardsController(IUserRewardService service)
        {
            this._service = service;
        }
    }

}
