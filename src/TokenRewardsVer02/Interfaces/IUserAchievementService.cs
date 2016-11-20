using System.Collections.Generic;
using TokenRewardsVer02.Models;
using TokenRewardsVer02.ViewModels.Achievement;

namespace TokenRewardsVer02.Interfaces
{
    public interface IUserAchievementService
    {
        void ClaimAchievement(string userid, int aid);
        IList<AchievementForView> GetAchievementsByUserName(string userName);
        IList<UserAchievements> GetAllUserAchievements();
    }
}