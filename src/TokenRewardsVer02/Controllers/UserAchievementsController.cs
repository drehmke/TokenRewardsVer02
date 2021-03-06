﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;
using System.Security.Principal;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TokenRewardsVer02.Controllers
{
    [Route("api/[controller]")]
    public class UserAchievementsController : Controller
    {
        private IUserAchievementService _service;

        // GET: api/userachievements
        //[HttpGet]


        // GET api/userachievements/5
        [HttpGet("GetAchievements/")]
        public IActionResult GetAchievements()
        {
            string userName = this.User.Identity.Name;
            var list = _service.GetAchievementsByUserName(userName);
            return Ok(list);
        }


        // POST api/userachievements
        [HttpPost]
        public IActionResult Post([FromBody]UserAchievements userAchievement)
        {
            string userName = this.User.Identity.Name;
            _service.ClaimAchievement(userName, userAchievement.AchievementId);
            return Ok();
        }

        // DELETE api/userachievements/5
        //[HttpDelete("{id}")]
        

        public UserAchievementsController(IUserAchievementService service )
        {
            this._service = service;
        }
    }
}
