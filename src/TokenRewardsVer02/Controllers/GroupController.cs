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
    public class GroupController : Controller
    {
        IGroupService _service;

        // admin
        [HttpGet]
        public IEnumerable<Group> Get()
        {
            return _service.GetAllGroups();
        }

        // all
        [HttpGet("{activeFlag}")]
        public IEnumerable<Group> GetByActiveFlag(bool activeFlag)
        {
            return _service.GetAllByActive(activeFlag);
        }

        // all ?
        [HttpGet("{id}")]
        public Group Get(int id)
        {
            return _service.GetGroupById(id);
        }

        // admin
        [HttpPost]
        public IActionResult Post([FromBody]Group groupToSave)
        {
            _service.SaveGroup(groupToSave);
            return Ok(groupToSave);
        }

        // admin
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.SoftDeleteGroup(id);
            return Ok();
        }

        public GroupController(IGroupService service)
        {
            this._service = service;
        }
    }
}
