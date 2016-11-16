using System.Collections.Generic;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Interfaces
{
    public interface IUserRewardService
    {
        void ClaimReward(string userId, int rewardId);
        IList<UserRewards> GetAllUserRewards();
        IList<UserRewards> GetRewardsByUserId(string userId);
    }
}