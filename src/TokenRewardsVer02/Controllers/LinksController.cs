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
    public class LinksController : Controller
    {
        ILinkService _service;

        // GET: api/links
        [HttpGet]
        public IEnumerable<Link> GetAllLinks()
        {
            IList<Link> linksList = _service.GetAllLinks();
            return linksList;
        }

        // GET api/links/5
        [HttpGet("{id}")]
        public Link Get(int id)
        {
            Link linkToShow = _service.GetLinkById(id);
            return linkToShow;
        }

        // POST api/links
        [HttpPost]
        public IActionResult Post([FromBody]Link linkToSave)
        {
            _service.SaveLink(linkToSave);
            return Ok(linkToSave);
        }

        // DELETE api/links/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }

        public LinksController(ILinkService service)
        {
            this._service = service;
        }
    }
}
