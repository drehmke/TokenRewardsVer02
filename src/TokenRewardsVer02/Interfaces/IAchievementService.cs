using System.Collections.Generic;
using TokenRewardsVer02.Models;
using TokenRewardsVer02.ViewModels.Achievement;

namespace TokenRewardsVer02.Interfaces
{
    public interface IAchievementService
    {
        void DeleteAchievement(int id);
        IList<AchievementForView> GetAllAchievements();
        AchievementForView GetByAchievementId(int id);
        void SaveAchievement(AchievementForView achievementToSave);
    }
}