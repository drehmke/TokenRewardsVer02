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
    public class RankController : Controller
    {
        IRankService _service;

        // GET: api/values
        [HttpGet] // admin
        public IEnumerable<Rank> Get()
        {
            IList<Rank> ranks = _service.GetAllRanks();
            return ranks;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Rank Get(int id)
        {
            Rank rank = _service.GetRankById(id);
            return rank;
        }

        // POST api/values
        [HttpPost] // admin
        public IActionResult Post([FromBody]Rank rankToSave)
        {
            _service.SaveRank(rankToSave);
            return Ok(rankToSave);
        }
        
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.SoftDelete(id);
            return Ok();
        }

        public RankController( IRankService service)
        {
            this._service = service;
        }
    }
}
