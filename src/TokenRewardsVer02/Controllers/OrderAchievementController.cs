﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TokenRewardsVer02.ViewModels.Orders;
using TokenRewardsVer02.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TokenRewardsVer02.Controllers
{
    [Route("api/[controller]")]
    public class OrderAchievementController : Controller
    {
        private IOrderAchievementService _service;

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("/getPlayerOrders")]
        public IEnumerable<OrderAchievementPlayerView> GetPlayerOrders()
        {
            string userName = this.User.Identity.Name;
            IList<OrderAchievementPlayerView> playerAchievementOrders = _service.GetAllOrderedAchievementsByUserName( userName );
            return playerAchievementOrders;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public OrderAchievementController( IOrderAchievementService service)
        {
            this._service = service;
        }
    }
}
