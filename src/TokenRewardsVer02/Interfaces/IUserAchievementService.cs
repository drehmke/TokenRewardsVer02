using System.Collections.Generic;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Interfaces
{
    public interface IUserAchievementService
    {
        void ClaimAchievement(string userid, int aid);
        IList<Achievement> GetAchievementsByUserName(string userName);
        IList<UserAchievements> GetAllUserAchievements();
    }
}