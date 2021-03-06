﻿using Microsoft.AspNetCore.Identity;
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
    public class CharacterService : ICharacterService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;

        // User views
        private UserProfileView ConvertToUserView(Character characterToConvert)
        {
            UserProfileView converted = new UserProfileView();
            converted.Id = characterToConvert.Id;
            converted.Name = characterToConvert.Name;
            converted.Active = characterToConvert.Active;

            return converted;
        }

        public IList<UserProfileView> GetMyCharacters(string uid)
        {
            IList<Character> userCharacters = _repo.Query<Character>().Include(c => c.User).ToList();
            IList<UserProfileView> charactersForView = new List<UserProfileView>();
            foreach( Character character in userCharacters)
            {
                if( character.User.Id == uid )
                {
                    UserProfileView listable = this.ConvertToUserView(character);
                    charactersForView.Add(listable);
                }
            }
            return charactersForView;
        }

        public UserProfileView GetMySingleCharacter(int id, string uid)
        {
            Character character = _repo.Query<Character>().Where(c => c.Id == id).Include(c => c.User).FirstOrDefault();
            UserProfileView characterForView = new UserProfileView();
            if( character.User.Id == uid)
            {
                characterForView = this.ConvertToUserView(character);
            }

            return characterForView;
        }

        public void SaveCharacter(Character characterToSave, string uid)
        {
            if (uid != null)
            {
                if (characterToSave.Id == 0)
                {
                    ApplicationUser user = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
                    characterToSave.User = user;
                    characterToSave.Active = true;
                    _repo.Add(characterToSave);
                }
                else
                {
                    _repo.Update(characterToSave);
                }
            }
        }

        // Admin views
        private AdminView ConvertToAdminView(Character characterToConvert)
        {
            AdminView converted = new AdminView();
            converted.Id = characterToConvert.Id;
            converted.Name = characterToConvert.Name;
            converted.UserName = characterToConvert.User.UserName;
            converted.WufooFormId = characterToConvert.WufooFormId;
            converted.Active = characterToConvert.Active;

            return converted;
        }

        public IList<AdminView> GetAllCharacters()
        {
            IList<Character> allCharacters = _repo.Query<Character>().Include(c => c.User).ToList();
            IList<AdminView> listView = new List<AdminView>();
            foreach( Character character in allCharacters)
            {
                AdminView listable = this.ConvertToAdminView(character);
            }
            return listView;
        }

        public AdminView GetSingleCharacter(int id)
        {
            Character character = _repo.Query<Character>().Where( c => c.Id == id ).Include(c => c.User).FirstOrDefault();
            AdminView characterToView = this.ConvertToAdminView(character);
            return characterToView;
        }

        public void AdminUpdateCharacter(Character characterToSave)
        {
            _repo.Update(characterToSave);
        }

        // All Users
        public void SoftDelete(int id)
        {
            Character characterToDelete = _repo.Query<Character>().Where(c => c.Id == id).FirstOrDefault();
            characterToDelete.Active = false;
            _repo.Update(characterToDelete);
        }

        public void Delete(int id)
        {
            Character characterToDelete = _repo.Query<Character>().Where(c => c.Id == id).FirstOrDefault();
            _repo.Delete(characterToDelete);
        }

        public CharacterService(IGenericRepository repo, UserManager<ApplicationUser> _manager)
        {
            this._repo = repo;
            this._manager = _manager;
        }
    }
}
