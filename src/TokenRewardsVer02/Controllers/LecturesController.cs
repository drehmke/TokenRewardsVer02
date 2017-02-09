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
    public class LecturesController : Controller
    {
        ILectureService _service;

        // GET: api/lectures
        [HttpGet]
        public IEnumerable<Lecture> Get()
        {
            IList<Lecture> viewableLectures = _service.GetAllLectures();
            return viewableLectures;
        }

        // GET api/lectures/5
        [HttpGet("{id}")]
        public Lecture Get(int id)
        {
            Lecture viewableLecture = _service.GetLectureById(id);
            return viewableLecture;
        }

        [HttpGet("/byPresenter/{presenterId}")]
        public IEnumerable<Lecture> GetByPresenter(string presenterId)
        {
            IList<Lecture> viewableLectures = _service.GetAllLecturesByPresenterId(presenterId);
            return viewableLectures;
        }

        // POST api/lectures
        [HttpPost]
        public IActionResult Post([FromBody]Lecture lectureToSave)
        {
            _service.SaveLecture(lectureToSave);
            return Ok(lectureToSave);
        }

        // DELETE api/lectures/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteLecture(id);
            return Ok();
        }

        public LecturesController(ILectureService service)
        {
            this._service = service;
        }
    }
}
