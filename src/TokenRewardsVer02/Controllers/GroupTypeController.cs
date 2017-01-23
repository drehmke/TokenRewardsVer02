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
    public class GroupTypeController : Controller
    {
        IGroupTypeService _service;

        // public / all
        [HttpGet]
        public IEnumerable<GroupType> GetAllGroupTypes()
        {
            return _service.GetAllGroupTypes();
        }

        // admin
        [HttpPost]
        public IActionResult Post([FromBody] GroupType typeToSave)
        {
            _service.SaveGroupType(typeToSave);
            return Ok(typeToSave);
        }

        // admin
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if( id != 0 )
            {
                _service.DeleteGroupType(id);
            }
            return Ok();
        }

        public GroupTypeController(IGroupTypeService service)
        {
            this._service = service;
        }
    }
}
