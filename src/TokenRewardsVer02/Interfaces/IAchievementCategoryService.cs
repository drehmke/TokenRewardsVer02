using System.Collections.Generic;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Interfaces
{
    public interface IAchievementCategoryService
    {
        void DeleteAchievementCategory(int id);
        IList<AchievementCategory> GetAllAchievementCategories();
        AchievementCategory GetByAchievementCategoryId(int id);
        AchievementCategory GetByFilterCategory(string filterCategory);
        void SaveAchievementCategory(AchievementCategory categoryToSave);

    }
}