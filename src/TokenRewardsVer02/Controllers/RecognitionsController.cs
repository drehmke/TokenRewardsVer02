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
    public class RecognitionsController : Controller
    {
        IRecognitionService _service;

        // GET: api/recognitions
        [HttpGet]
        public IEnumerable<Recognition> Get()
        {
            IEnumerable<Recognition> allRecognitions = _service.GetAllRecognitions();
            return allRecognitions;
        }

        // GET api/recognitions/5
        [HttpGet("{id}")]
        public Recognition Get(int id)
        {
            Recognition viewableRecognition = _service.GetRecognitionById(id);
            return viewableRecognition;
        }

        // POST api/recognitions
        [HttpPost]
        public IActionResult Post([FromBody]Recognition recognitionToSave)
        {
            _service.SaveRecognition(recognitionToSave);
            return Ok(recognitionToSave);
        }

        // DELETE api/recognitions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteRecognition(id);
            return Ok();
        }

        public RecognitionsController(IRecognitionService service)
        {
            this._service = service;
        }
    }
}
