using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Services
{
    public class AchievementService : IAchievementService
    {
        private IGenericRepository _repo;

        // ---- Basic CRUD -------------------------------------------------------
        public IList<Achievement> GetAllAchievements()
        {
            return _repo.Query<Achievement>().ToList();
        }

        public Achievement GetByAchievementId(int id)
        {
            return _repo.Query<Achievement>().Where(a => a.Id == id).FirstOrDefault();
        }

        public void SaveAchievement(Achievement achievementToSave)
        {
            if(achievementToSave.Id == 0 )
            {
                _repo.Add(achievementToSave);
            } else
            {
                _repo.Update(achievementToSave);
            }
        }

        public void DeleteAchievement(int id)
        {
            Achievement achievementToDelete = _repo.Query<Achievement>().Where(a => a.Id == id).FirstOrDefault();
            _repo.Delete(achievementToDelete);
        }
        // ---- End Basic CRUD ---------------------------------------------------
        // ---- If adding anything below this line - re-extract the Interface ----

        public AchievementService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}
