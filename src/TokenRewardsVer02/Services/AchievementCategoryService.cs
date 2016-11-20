using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenRewardsVer02.Interfaces;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Services
{
    public class AchievementCategoryService : IAchievementCategoryService
    {
        private IGenericRepository _repo;

        public IList<AchievementCategory> GetAllAchievementCategories()
        {
            return _repo.Query<AchievementCategory>().ToList();
        }

        public AchievementCategory GetByAchievementCategoryId(int id)
        {
            return _repo.Query<AchievementCategory>().Where(a => a.Id == id).FirstOrDefault();
        }
        public AchievementCategory GetByFilterCategory(string filterCategory)
        {
            return _repo.Query<AchievementCategory>().Where(a => a.FilterCategory == filterCategory).FirstOrDefault();
        }

        public void SaveAchievementCategory(AchievementCategory categoryToSave)
        {
            if(categoryToSave.Id == 0 )
            {
                _repo.Add(categoryToSave);
            } else
            {
                _repo.Update(categoryToSave);
            }
        }

        public void DeleteAchievementCategory(int id)
        {
            AchievementCategory categoryToDelete = _repo.Query<AchievementCategory>().Where(a => a.Id == id).FirstOrDefault();
            _repo.Delete(categoryToDelete);
        }


        public AchievementCategoryService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}
