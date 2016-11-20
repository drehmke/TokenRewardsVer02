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
    public class AchievementCategoriesController : Controller
    {
        private IAchievementCategoryService _service;

        [HttpGet]
        public IEnumerable<AchievementCategory> Get()
        {
            IEnumerable<AchievementCategory> test = _service.GetAllAchievementCategories();
            return test;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetByAchievementCategoryId(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]AchievementCategory category)
        {
            _service.SaveAchievementCategory(category);
            return Ok(category);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteAchievementCategory(id);
            return Ok();
        }

        public AchievementCategoriesController(IAchievementCategoryService service)
        {
            this._service = service;
        }
    }
}
