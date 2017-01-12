using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;
using TokenRewardsVer02.ViewModels.Character;

namespace TokenRewardsVer02.Services
{
    public class CharacterService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;

        // User views
        public IList<UserProfileView> GetMyCharacters(string uid)
        {
            IList<Character> userCharacters = _repo.Query<Character>().Where( c => c.User.Id == uid ).Include( c => c.User ).ToList();
            IList<UserProfileView> charactersForView = new List<UserProfileView>();
            foreach( Character character in userCharacters)
            {
                UserProfileView listable = new UserProfileView();
                listable.Id = character.Id;
                listable.Name = character.Name;
                charactersForView.Add(listable);
            }
            return charactersForView;
        }

        public UserProfileView GetMySingleCharacter(int id)
        {
            Character character = _repo.Query<Character>().Where(c => c.Id == id).Include(c => c.User).FirstOrDefault();
            UserProfileView characterForView = new UserProfileView();
            characterForView.Id = character.Id;
            characterForView.Name = character.Name;
            characterForView.Active = character.Active;

            return characterForView;
        }

        public void SaveCharacter(Character characterToSave, string uid)
        {
            if(uid != null)
            {
                if( characterToSave.Id == 0)
                {
                    ApplicationUser user = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
                    characterToSave.User = user;
                    characterToSave.Active = true;
                    _repo.Add(characterToSave);
                } else
                {
                    _repo.Update(characterToSave);
                }
            }
        }

        public void SoftDelete(int id)
        {
            Character characterToDelete = _repo.Query<Character>().Where( c => c.Id == id).FirstOrDefault();
            characterToDelete.Active = false;
            _repo.Update(characterToDelete);
        }

        // Admin views

        public CharacterService(IGenericRepository repo, UserManager<ApplicationUser> _manager)
        {
            this._repo = repo;
            this._manager = _manager;
        }
    }
}
