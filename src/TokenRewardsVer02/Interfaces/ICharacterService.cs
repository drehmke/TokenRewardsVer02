using System.Collections.Generic;
using TokenRewardsVer02.Models;
using TokenRewardsVer02.ViewModels.Character;

namespace TokenRewardsVer02.Interfaces
{
    public interface ICharacterService
    {
        void Delete(int id);
        IList<AdminView> GetAllCharacters();
        IList<UserProfileView> GetMyCharacters(string uid);
        UserProfileView GetMySingleCharacter(int id, string uid);
        AdminView GetSingleCharacter(int id);
        void SaveCharacter(Character characterToSave, string uid);
        void AdminUpdateCharacter(Character characterToSave);
        void SoftDelete(int id);
    }
}