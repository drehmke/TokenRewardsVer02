using System.Collections.Generic;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Interfaces
{
    public interface IAchievementService
    {
        void DeleteAchievement(int id);
        IList<Achievement> GetAllAchievements();
        Achievement GetByAchievementId(int id);
        void SaveAchievement(Achievement achievementToSave);
    }
}