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
    public class StoriesController : Controller
    {
        IStoryService _service;

        // GET: api/stories
        [HttpGet]
        public IEnumerable<Story> Get()
        {
            IEnumerable<Story> allStories = _service.GetAllStories();
            return allStories;
        }

        // GET api/stories/5
        [HttpGet("{id}")]
        public Story Get(int id)
        {
            Story viewableStory = _service.GetStoryById(id);
            return viewableStory;
        }

        // POST api/stories
        [HttpPost]
        public IActionResult Post([FromBody]Story storyToSave)
        {
            _service.SaveStory(storyToSave);
            return Ok(storyToSave);
        }

        // DELETE api/stories/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteStory(id);
            return Ok();
        }

        public StoriesController(IStoryService service)
        {
            this._service = service;
        }
    }
}
