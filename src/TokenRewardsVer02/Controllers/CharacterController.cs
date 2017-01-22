using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.ViewModels.Character;
using TokenRewardsVer02.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TokenRewardsVer02.Controllers
{
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        ICharacterService _service;
        UserManager<ApplicationUser> _manager;

        private string getUserId()
        {
            string uid = this._manager.GetUserId(User);
            return uid;
        }

        // User Views ---------------------------------------------------------
        [HttpGet("GetAllMyCharacters/")]
        public IEnumerable<UserProfileView> GetAllMyCharacters()
        {
            string uid = this.getUserId();
            IList<UserProfileView> listForView = this._service.GetMyCharacters(uid);
            return listForView;
        }

        [HttpGet("GetMySingleCharacter/{id}")]
        public UserProfileView GetMySingleCharacter(int id)
        {
            string uid = this.getUserId();
            UserProfileView characterForView = this._service.GetMySingleCharacter(id, uid);
            return characterForView;
        }

        [HttpPost]
        public IActionResult SaveMyCharacter([FromBody]Character characterToSave)
        {
            string uid = this.getUserId();
            _service.SaveCharacter(characterToSave, uid);
            return Ok(characterToSave);
        }

        [HttpDelete("SoftDelete/{id}")]
        public IActionResult SoftDelete(int id)
        {
            this._service.SoftDelete(id);
            return Ok();
        }

        // Admin Views --------------------------------------------------------
        [HttpGet]
        public IEnumerable<AdminView> AdminGetAllCharacters()
        {
            IList<AdminView> listForView = this._service.GetAllCharacters();
            return listForView;
        }

        [HttpGet("AdminGetSingleCharacter/{id}")]
        public AdminView AdminGetSingleCharacter(int id)
        {
            AdminView forView = this._service.GetSingleCharacter(id);
            return forView;
        }

        [HttpPost("AdminUpdate/")]
        public IActionResult AdminUpdateCharacter([FromBody]Character characterToSave)
        {
            this._service.AdminUpdateCharacter(characterToSave);
            return Ok(characterToSave);
        }

        [HttpDelete("AdminSoftDelete/{id}")]
        public IActionResult AdminSoftDelete(int id)
        {
            this._service.SoftDelete(id);
            return Ok();
        }

        [HttpDelete("AdminHardDelete/{id}")]
        public IActionResult AdminHardDelete(int id)
        {
            this._service.Delete(id);
            return Ok();
        }

        // Constructor --------------------------------------------------------
        public CharacterController(ICharacterService service, UserManager<ApplicationUser> manager)
        {
            this._service = service;
            this._manager = manager;
        }

    }
}
