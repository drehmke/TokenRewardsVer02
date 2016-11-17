﻿using System;
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

        [HttpGet("GetRewards/{userName}")]
        public IActionResult GetRewards(string userName)
        {
            var list = _service.GetRewardsByUserName(userName);
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserRewards userRewards)
        {
            _service.ClaimReward(userRewards.UserId, userRewards.RewardId);
            return Ok();
        }

        public UserRewardsController(IUserRewardService service)
        {
            this._service = service;
        }
    }

}