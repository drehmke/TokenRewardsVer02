using System.Collections.Generic;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Interfaces
{
    public interface IUserAchievementService
    {
        void ClaimAchievement(string userid, int aid);
        IList<UserAchievements> GetAchievementsByUserName(string userId);
        //void getAchievmentByUserId(string userid, int aid);
        IList<UserAchievements> GetAllUserAchievements();
    }
}